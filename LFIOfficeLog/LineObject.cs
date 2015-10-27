using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class LineObject
    {
        public Point p0;
        public Point p;
        public int width=1;
        public Color color=Color.Black;
        public LineObject(Point p0, Point p)
        {
            this.p0 = p0;
            this.p = p;
        }
    }
}
