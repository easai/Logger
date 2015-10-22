using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        List<Rectangle> list = new List<Rectangle>();

        public ImageEditor(int id, Image image)
        {
            this.id = id;
            this.image = image;
            InitializeComponent();
            if (image != null)
            {
                pictureBox.Image = image;
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
            Size size=new Size(e.X-pos.X, e.Y-pos.Y);
            Rectangle r = new Rectangle(pos, size);
            list.Add(r);
            Refresh();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawRectangle(new Pen(Color.Blue), new Rectangle(0, 0, 100, 100));
            draw(g);
        }

        private void draw(Graphics g)
        {
            Pen pen = new Pen(Color.Red);
            g.DrawRectangle(new Pen(Color.Green), new Rectangle(0, 0, 100, 100));

            foreach (Rectangle rect in list)
            {
                g.DrawRectangle(pen, rect);
            }
        }

        private void drawOnImage(Graphics g)
        {
            Pen pen = new Pen(Color.Red);
            foreach (Rectangle rect in list)
            {
                float f = 1.0f;
                Point r0;
                if (pictureBox.Width * image.Height < image.Width * pictureBox.Height)
                {
                    f = (float)image.Width / pictureBox.Width;
                    r0 = new Point(0, (int)((pictureBox.Height - image.Height/f) * .5));
                }
                else
                {
                    f = (float)image.Height / pictureBox.Height;
                    r0 = new Point((int)((pictureBox.Width - image.Width/f) * .5), 0);
                }

                Rectangle r = new Rectangle();
                r.X = (int)((rect.X-r0.X) * f);
                r.Y = (int)((rect.Y-r0.Y) * f);
                r.Width = (int)(rect.Width * f);
                r.Height = (int)(rect.Height * f);
                g.DrawRectangle(pen, r);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
    }
}
