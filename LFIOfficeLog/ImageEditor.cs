using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logger
{
    public partial class ImageEditor : Form
    {
        Image image;
        Point pos;
        int id;
        List<RectangleObject> list = new List<RectangleObject>();
        enum Mode { SELECT, DRAW, TEXT };
        Mode mode;
        List<TextObject> textList = new List<TextObject>();
        RichTextBox textBox = new RichTextBox();
        public int lineWidth = 1;
        public Color lineColor = Color.SteelBlue;
        public Font font = new Font("Segoe UI", 16);
        public Color fontColor = Color.SteelBlue;

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

            switch (mode)
            {
                case Mode.SELECT:
                    for (int i = 0; i < list.Count(); i++)
                    {
                        if (list[i].Contains(pos))
                        {
                            RectangleObject rect = new RectangleObject(
                                list[i].rect.X + e.Location.X - pos.X,
                                list[i].rect.Y + e.Location.Y - pos.Y,
                                list[i].rect.Width,
                                list[i].rect.Height);
                            rect.width = list[i].width;
                            list.Remove(list[i]);
                            list.Add(rect);
                        }
                    }
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
                    break;
                case Mode.DRAW:
                    Size size = new Size(e.X - pos.X, e.Y - pos.Y);
                    RectangleObject r = new RectangleObject(pos, size);
                    r.width = lineWidth;
                    r.color = lineColor;
                    list.Add(r);
                    break;
                case Mode.TEXT:
                    if (!textBox.Visible)
                    {
                        textBox.Location = e.Location;
                        textBox.Show();
                    }
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
            foreach (RectangleObject r in list)
            {
                Pen pen = new Pen(r.color);
                pen.Width = r.width;
                g.DrawRectangle(pen, r.rect);
            }
            foreach (TextObject text in textList)
            {
                Brush brush = new SolidBrush(text.color);
                g.DrawString(text.text, text.font, (Brush)brush, text.pos);

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

            foreach (RectangleObject ro in list)
            {
                Pen pen = new Pen(ro.color);
                Rectangle r = new Rectangle();
                r.X = (int)((ro.rect.X - r0.X) * f);
                r.Y = (int)((ro.rect.Y - r0.Y) * f);
                r.Width = (int)(ro.rect.Width * f);
                r.Height = (int)(ro.rect.Height * f);
                pen.Width = ro.width;
                g.DrawRectangle(pen, r);
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

        private void lineWidthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new LineWidth(this).ShowDialog();
        }

        private void lineColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                lineColor = dialog.Color;
            }
        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fontColor = dialog.Color;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                font = dialog.Font;
            }
        }

    }
}
