using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeorProg2.Model;
using TeorProg2.Property;

namespace TeorProg2.GraphicItems
{
    class Ellipse : Figure
    {
        public Ellipse(Frame frame, PropList propList) : base(frame, propList)
        {

        }

        protected override void DrawGeometry(Model.GraphSystem graphSystem)
        {
            graphSystem.DrawEllipse(Frame);
        }

        public override Selection CreateSelection()
        {
            return new EllipseSelection(this);
        }

        public override bool InBody(int x, int y)
        {
            int Xmid = Frame.x1 + (Frame.x2 - Frame.x1) / 2;
            int Ymid = Frame.y1 + (Frame.y2 - Frame.y1) / 2;
            double Xl = (double)(x - Xmid) / (double)((Frame.x2 - Frame.x1)/2);
            double Yl = (double)(y - Ymid) / (double)((Frame.y2 - Frame.y1) / 2);
            if (Math.Pow(Xl, 2)+Math.Pow(Yl, 2)<=1)
            {
                oldX = x; oldY = y;
                return true;
            }
            return false;
        }
    }
}
