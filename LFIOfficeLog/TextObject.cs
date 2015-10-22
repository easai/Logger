using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class TextObject
    {
        public Point pos;
        public string text;
        public Font font=new Font("Segoe UI",16);
        public Color color=Color.SteelBlue;

        public TextObject(Point pos, string text, Font font)
        {
            this.font = font;
            this.pos = pos;
            this.text = text;
        }
    }
}
