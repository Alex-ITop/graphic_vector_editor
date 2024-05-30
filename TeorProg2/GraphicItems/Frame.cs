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
            x1 = Math.Min(x1, otherFrame.x1);
            y1 = Math.Min(y1, otherFrame.y1);
            x2 = Math.Max(x2, otherFrame.x2);
            y2 = Math.Max(y2, otherFrame.y2);
        }
    }
}
