using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class PolygonObject
    {
        public List<Point> list = new List<Point>();
        public Pen pen = new Pen(Color.Black);
        public void addPoint(Point pos)
        {
            list.Add(pos);
        }
        public void shift(int x, int y)
        {
            List<Point> l = new List<Point>();
            for (int i = 0; i < list.Count(); i++)
            {
                l.Add(new Point(list[i].X + x,list[i].Y + y)); 
            }
            list = l;
        }
        public Point[] scale(float f)
        {
            Point[] p = list.ToArray();
            for (int i = 0; i < p.Length; i++)
            {
                p[i].X = (int)(p[i].X * f);
                p[i].Y = (int)(p[i].Y * f);
            }
            return p;
        }
        public void rectangle(Point start, Point end)
        {
            addPoint(start);
            addPoint(new Point(start.X, end.Y));
            addPoint(end);
            addPoint(new Point(end.X, start.Y));
            addPoint(start);
        }
        public void setPen(Pen pen)
        {
            this.pen = (Pen)pen.Clone();
        }
    }
}
