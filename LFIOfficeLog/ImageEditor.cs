using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Logger
{
    public partial class ImageEditor : Form
    {
        Image image;
        Point pos;
        int id;
        List<PolygonObject> polygonList = new List<PolygonObject>();
        enum Mode { SELECT, DRAW, TEXT, LINE };
        Mode mode;
        List<TextObject> textList = new List<TextObject>();
        RichTextBox textBox = new RichTextBox();
        public Font font = new Font("Segoe UI", 16);
        public Color fontColor = Color.SteelBlue;
        public Pen pen=new Pen(Color.SteelBlue);
        
        public ImageEditor(int id, Image image)
        {
            this.id = id;
            this.image = image;
            InitializeComponent();
            if (image != null)
            {
                pictureBox.Image = image;
            }
            mode = Mode.DRAW;
            setMode();
            textBox.Font = new Font("Segoe UI", 16);
            textBox.Hide();
            textBox.Size = new Size(500, 100);
            pictureBox.Controls.Add(textBox);
        }

        private void setMode()
        {
            selectButton.Checked = false;
            shapeButton.Checked = false;
            textButton.Checked = false;
            lineButton.Checked = false;
            switch (mode)
            {
                case Mode.SELECT:
                    selectButton.Checked = true;
                    break;
                case Mode.DRAW:
                    shapeButton.Checked = true;
                    break;
                case Mode.TEXT:
                    textButton.Checked = true;
                    break;
                case Mode.LINE:
                    lineButton.Checked = true;
                    break;
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            pos = e.Location;
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (textBox.Visible)
            {
                TextObject textObject = new TextObject(textBox.Location, textBox.Text, font);
                textObject.color = fontColor;
                textList.Add(textObject);
                textBox.Clear();
                textBox.Hide();
                pictureBox.Refresh();
            }
            bool moved = false;
            switch (mode)
            {
                case Mode.SELECT:
                   
                    for (int i = 0; i < polygonList.Count(); i++)
                    {
                        GraphicsPath path = new GraphicsPath();
                        path.AddPolygon(polygonList[i].list.ToArray());
                        Region region = new Region(path);
                        
                        if (region.GetBounds(CreateGraphics()).Contains(pos))
                        {
                            polygonList[i].shift(e.Location.X - pos.X, e.Location.Y - pos.Y);
                            moved = true;
                        }
                    }
                    if (!moved)
                    {
                        for (int i = 0; i < textList.Count(); i++)
                        {
                            SizeF sizeF = pictureBox.CreateGraphics().MeasureString(textList[i].text, textList[i].font);
                            Rectangle rb = new Rectangle(textList[i].pos.X, textList[i].pos.Y, (int)sizeF.Width, (int)sizeF.Height);
                            if (rb.Contains(pos))
                            {
                                textList[i].pos.X += e.Location.X - pos.X;
                                textList[i].pos.Y += e.Location.Y - pos.Y;
                            }
                        }
                    }
                    break;
                case Mode.DRAW:
                    PolygonObject poly = new PolygonObject();
                    poly.rectangle(pos, e.Location);
                    poly.setPen(pen);
                    polygonList.Add(poly);
                    break;
                case Mode.TEXT:
                    if (!textBox.Visible)
                    {
                        textBox.Location = e.Location;
                        textBox.Show();
                    }
                    break;
                case Mode.LINE:
                    PolygonObject polygon = new PolygonObject();
                    polygon.addPoint(pos);
                    polygon.addPoint(e.Location);
                    polygon.setPen(pen);
                    polygonList.Add(polygon);
                    break;
            }
            Refresh();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            draw(g);
        }

        private void draw(Graphics g)
        {
            foreach (TextObject text in textList)
            {
                Brush brush = new SolidBrush(text.color);
                g.DrawString(text.text, text.font, (Brush)brush, text.pos);

            }
            foreach (PolygonObject polygon in polygonList)
            {
                g.DrawPolygon(polygon.pen, polygon.list.ToArray());
            }
        }

        private void drawOnImage(Graphics g)
        {
            float f = 1.0f;
            Point r0;
            if (pictureBox.Width * image.Height < image.Width * pictureBox.Height)
            {
                f = (float)image.Width / pictureBox.Width;
                r0 = new Point(0, (int)((pictureBox.Height - image.Height / f) * .5));
            }
            else
            {
                f = (float)image.Height / pictureBox.Height;
                r0 = new Point((int)((pictureBox.Width - image.Width / f) * .5), 0);
            }

            foreach (PolygonObject polygon in polygonList)
            {
                g.DrawPolygon(polygon.pen, polygon.scale(f));
            }
            foreach (TextObject text in textList)
            {
                Font font = new Font("Segoe UI", (int)(16 * f));
                Brush brush = new SolidBrush(text.color);
                Point p = new Point();
                p.X = (int)((text.pos.X - r0.X) * f);
                p.Y = (int)((text.pos.Y - r0.Y) * f);
                g.DrawString(text.text, font, (Brush)brush, p);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog { };
            if (fileDialog.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                string fileName = fileDialog.FileName;
                drawOnImage(Graphics.FromImage(image));
                CultureInfo ci = new CultureInfo("en-US");

                if (fileName.EndsWith(".jpg", true, CultureInfo.CurrentCulture))
                {
                    image.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else if (fileName.EndsWith(".bmp", true, CultureInfo.CurrentCulture))
                {
                    image.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                }
                else if (fileName.EndsWith(".png", true, CultureInfo.CurrentCulture))
                {
                    image.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                }
                else
                {
                    image.Save(fileName + ".png", System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (MemoryStream ms = new MemoryStream())
            {

                float fx = (float)pictureBox.Image.Width / pictureBox.Width;
                float fy = (float)pictureBox.Image.Height / pictureBox.Height;
                drawOnImage(Graphics.FromImage(image));

                pictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                byte[] array = ms.ToArray();

                using (var db = new OfficeLog())
                {
                    var entry = db.Photos.Single(x => x.Id == id);
                    entry.PhotoData = array;

                    int recordsAffected = db.SaveChanges();
                }
                Dispose();
            }
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            mode = Mode.SELECT;
            setMode();
        }

        private void shapeButton_Click(object sender, EventArgs e)
        {
            mode = Mode.DRAW;
            setMode();
        }

        private void textButton_Click(object sender, EventArgs e)
        {
            mode = Mode.TEXT;
            setMode();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            mode = Mode.LINE;
            setMode();
        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = fontColor;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fontColor = dialog.Color;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();
            dialog.Font = font;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                font = dialog.Font;
            }
        }

        private void lineColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = pen.Color;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pen.Color = dialog.Color;
            }
        }

        private void lineWdithToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new LineWidth(this).ShowDialog();
        }

    }
}
