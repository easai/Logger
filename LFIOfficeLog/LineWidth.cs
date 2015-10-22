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
    public partial class LineWidth : Form
    {
        ImageEditor imageEditor;
        public LineWidth(ImageEditor imageEditor)
        {
            this.imageEditor = imageEditor;
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            int w = (int)widthUpDown.Value;
            if (w == 0)
                w = 1;
            imageEditor.lineWidth = w;
            Close();
        }
    }
}
