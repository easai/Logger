using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logger
{
    class ImageBox: PictureBox
    {
        public int id;
        public ImageBox(int id)
        {
            this.id = id;
        }
    }
}
