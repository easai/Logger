﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.Globalization;

namespace Logger
{
    public partial class LoggerForm : Form
    {
        public LoggerForm()
        {
            InitializeComponent();
            refreshScreen();
        }

        private void setLogPanel(OfficeLog db)
        {
            layout.Controls.Clear();
            var items = from i in db.Entries select i;
            items = items.OrderByDescending(i => i.LogDate).Take(5);
            int height = (int)((this.Height - 130) / 5.0);

            LogButton[] editButtonList = new LogButton[5];
            LogButton[] deleteButtonList = new LogButton[5];
            for (int i = 0; i < 5; i++)
            {
                editButtonList[i] = new LogButton();
                editButtonList[i].Text = "&Edit";
                deleteButtonList[i] = new LogButton();
                deleteButtonList[i].Text = "&Delete";
            }

            int index = 0;
            foreach (var i in items)
            {
                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.Size = new Size(this.Width, height);
                deleteButtonList[index].id = i.Id;
                deleteButtonList[index].Click += (sender, e) =>
                {
                    using (var log = new OfficeLog())
                    {
                        var entry = log.Entries.Single(x => x.Id == ((LogButton)sender).id);
                        log.Entries.Remove(entry);
                        log.SaveChanges();
                        refreshScreen();
                    }
                };
                editButtonList[index].id = i.Id;
                editButtonList[index].rtf = i.LogText;
                editButtonList[index].Click += (sender, e) =>
                {
                    using (var log = new OfficeLog())
                    {
                        var edit = new EditEntry(((LogButton)sender).id, this);
                        edit.setRtf(((LogButton)sender).rtf);

                        edit.ShowDialog();
                    }
                };
                Label tb = new Label();
                tb.Width = 140;
                tb.Text = i.LogDate.ToString();
                RichTextBox richTextBox = new RichTextBox();
                richTextBox.Dock = DockStyle.Bottom;
                richTextBox.Size = new Size(this.Width - 30, height - 30);
                richTextBox.ReadOnly = true;
                richTextBox.BorderStyle = BorderStyle.None;
                richTextBox.BackColor = Color.White;
                try
                {
                    richTextBox.Rtf = i.LogText;
                }
                catch (Exception)
                {
                    richTextBox.Text += i.LogText;
                }
                using (Graphics g = CreateGraphics())
                {
                    richTextBox.Height = (int)g.MeasureString(richTextBox.Text,
                        richTextBox.Font, richTextBox.Width).Height;
                    panel.Height = Math.Min(height,richTextBox.Height + 30);
                }

                panel.Controls.Add(deleteButtonList[index]);
                panel.Controls.Add(editButtonList[index]);
                panel.Controls.Add(tb);
                panel.Controls.Add(richTextBox);

                layout.Controls.Add(panel);
                index++;
            }
        }

        private void setPhotoPanel(OfficeLog db)
        {
            this.photoPanel.Controls.Clear();
            var items = from i in db.Photos select i;
            items = items.OrderByDescending(i => i.PhotoTime).Take(5);
            int height = (int)((photoPanel.Height - 130) / 4);
            int width = (int)((photoPanel.Width - 30) / 3);

            int index = 0;
            foreach (var i in items)
            {
                Label tb = new Label();
                tb.Width = 140;
                tb.Text = i.PhotoTime.ToString();
                ImageBox pictureBox = new ImageBox(i.Id);

                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Dock = DockStyle.Bottom;
                pictureBox.Size = new Size(width, height - 30);
                byte[] buf = i.PhotoData;
                if (buf != null)
                {
                    MemoryStream ms = new MemoryStream(buf);
                    pictureBox.Image = Image.FromStream(ms);

                    ContextMenu contextMenu = new ContextMenu();
                    contextMenu.MenuItems.Add("Delete " + pictureBox.id, new System.EventHandler(deleteImage));
                    contextMenu.MenuItems.Add("Edit   " + pictureBox.id, new System.EventHandler(editImage));
                    contextMenu.MenuItems.Add("Save   " + pictureBox.id, new System.EventHandler(saveImage));
                    pictureBox.ContextMenu = contextMenu;

                    pictureBox.Click += (sender, e) =>
                    {
                        if (((MouseEventArgs)e).Button != MouseButtons.Right)
                        {
                            new ImageEditor(pictureBox.id, pictureBox.Image).Show();
                        }
                    };
                }
                photoPanel.Controls.Add(pictureBox);
                index++;
            }
        }

        public void deleteImage(object sender, EventArgs e)
        {
            using (var log = new OfficeLog())
            {
                MenuItem menuItem = ((MenuItem)sender);
                string str = menuItem.Text.Substring(7);
                int index = int.Parse(str);
                var entry = log.Photos.Single(x => x.Id == index);
                log.Photos.Remove(entry);
                log.SaveChanges();
                setPhotoPanel(log);
            }
        }

        public void editImage(object sender, EventArgs e)
        {
            using (var log = new OfficeLog())
            {
                MenuItem menuItem = ((MenuItem)sender);
                string str = menuItem.Text.Substring(7);
                int index = int.Parse(str);
                var entry = log.Photos.Single(x => x.Id == index);
                byte[] buf = entry.PhotoData;
                if (buf != null)
                {
                    MemoryStream ms = new MemoryStream(buf);
                    new ImageEditor(index, Image.FromStream(ms)).Show();
                }
                setPhotoPanel(log);
            }
        }

        public void saveImage(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog { };
            if (fileDialog.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                string fileName = fileDialog.FileName;
                using (var log = new OfficeLog())
                {
                    MenuItem menuItem = ((MenuItem)sender);
                    string str = menuItem.Text.Substring(7);
                    int index = int.Parse(str);
                    var entry = log.Photos.Single(x => x.Id == index);
                    byte[] buf = entry.PhotoData;
                    if (buf != null)
                    {
                        MemoryStream ms = new MemoryStream(buf);
                        Image image = Image.FromStream(ms);
                        
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
            } 
        }

        public void refreshScreen()
        {
            using (var db = new OfficeLog())
            {
                setLogPanel(db);
                setPhotoPanel(db);
                Refresh();
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void aboutLFIOfficeLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutLogger().Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new NewEntry(this).ShowDialog();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshScreen();
        }

        private void LoggerForm_SizeChanged(object sender, EventArgs e)
        {
            refreshScreen();
        }

        private void screenshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Opacity = 0;
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), bmp.Size);
            this.Opacity = 1.0;
            g.Dispose();

            saveBitmap(bmp);

            refreshScreen();
        }

        private void clipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image image=Clipboard.GetImage();
            if(image==null)
                return;
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(image,0,0);
            g.Dispose();

            saveBitmap(bmp);

            refreshScreen();
        }

        private void saveBitmap(Bitmap bmp)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                byte[] array = ms.ToArray();

                using (var log = new OfficeLog())
                {
                    var photo = new Photo
                    {
                        PhotoTime = DateTime.Now,
                        PhotoData = array
                    };
                    log.Database.Log = Console.WriteLine;
                    log.Photos.Add(photo);
                    log.SaveChanges();
                }
            }
        }
    }
}
