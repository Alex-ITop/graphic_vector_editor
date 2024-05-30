using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeorProg2.GraphicItems
{
    abstract class GraphItem
    {
        public Frame Frame { get; set; }
        public GraphItem(Frame frame)
        {
            if (Frame == null)
            {
                Frame = frame;
            }
        }

        abstract public void Draw(TeorProg2.Model.GraphSystem graphSystem);
    }
}
