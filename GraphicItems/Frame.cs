using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeorProg2.GraphicItems
{
    class Frame
    {
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }

        public Frame(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public void Add(Frame otherFrame)
        {
            Frame r = new Frame(Math.Min(x1, x2), Math.Min(y1, y2), Math.Max(x1, x2), Math.Max(y1, y2));
            Frame o = new Frame(Math.Min(otherFrame.x1, otherFrame.x2), Math.Min(otherFrame.y1, otherFrame.y2), Math.Max(otherFrame.x1, otherFrame.x2), Math.Max(otherFrame.y1, otherFrame.y2));
            x1 = Math.Min(r.x1, o.x1);
            y1 = Math.Min(r.y1, o.y1);
            x2 = Math.Max(r.x2, o.x2);
            y2 = Math.Max(r.y2, o.y2);
        }

        public void ChangeFrame(List<System.Drawing.Rectangle> Points)
        {
            x1 = Points.Min(point => point.X)+3;
            y1 = Points.Min(point => point.Y)+3;
            x2 = Points.Max(point => point.X)+3;
            y2 = Points.Max(point => point.Y) + 3;
        }
    }
}
