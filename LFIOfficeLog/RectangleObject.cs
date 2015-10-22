using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class RectangleObject
    {
        public Rectangle rect;
        public int width=1;
        public Color color = Color.SteelBlue;
        public RectangleObject(int x, int y, int width, int height)
        {
            rect = new Rectangle(x, y, width, height);
        }
        public RectangleObject(Point pos, Size size)
        {
            rect = new Rectangle(pos, size);
        }
        public bool Contains(Point pos)
        {
            return rect.Contains(pos);
        }
    }
}
