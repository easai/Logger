using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logger
{
    public partial class NewEntry : Form
    {
        LoggerForm logger;

        public NewEntry(LoggerForm logger)
        {
            this.logger = logger;
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            save();
        }

        public virtual void save()
        {
            using (var db = new OfficeLog())
            {
                var entry = new Entry
                {
                    LogDate = DateTime.Now,
                    LogText = newEntryText.Rtf
                };
                db.Entries.Add(entry);
                int recordsAffected = db.SaveChanges();
            }
            logger.refreshScreen();
            Dispose();
        }

        public string getRtf()
        {
            return newEntryText.Rtf;
        }

        public void setRtf(string rtf)
        {
            try
            {
                newEntryText.Rtf = rtf;
            }
            catch (Exception)
            {
                newEntryText.Text = rtf;
            }
        }

        private void imageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog { DefaultExt = "*.jpg" };
            if (fileDialog.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                string lstrFile = fileDialog.FileName;
                using (Bitmap myBitmap = new Bitmap(lstrFile))
                {
                    setImage(myBitmap);//add another father
                }
            } 
        }

        private void setImage(Image myBitmap)
        {
            int w, h;
            w = myBitmap.Width;
            h = myBitmap.Height;
            if (w < h)
            {
                if (300 < h)
                {
                    w = (int)(w * 300.0 / h);
                    h = 300;
                }
            }
            else
            {
                if (300 < w)
                {
                    h = (int)(h * 300.0 / w);
                    w = 300;
                }
            }
            Bitmap resized = new Bitmap(myBitmap, w, h);
            Clipboard.SetDataObject(resized);
            DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Bitmap);
            if (newEntryText.CanPaste(myFormat))
            {
                newEntryText.Paste(myFormat);
            }
            else
            {
                MessageBox.Show("The data format that you attempted site" +
                  " is not supportedby this control.");
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                newEntryText.SelectionFont = fontDialog.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                newEntryText.SelectionColor = colorDialog.Color;
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newEntryText.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newEntryText.Redo();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newEntryText.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newEntryText.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newEntryText.Paste();
        }

        private void captureScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
