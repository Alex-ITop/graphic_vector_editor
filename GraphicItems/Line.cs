using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeorProg2.Model;
using TeorProg2.Property;

namespace TeorProg2.GraphicItems
{
    class Line:Figure
    {
        public Line(Frame frame, PropList propList): base(frame, propList)
        {

        }

        protected override void DrawGeometry(Model.GraphSystem graphSystem)
        {
            graphSystem.DrawLine(Frame);
        }

        public override Selection CreateSelection()
        {
            return new LineSelection(this);
        }

        public override bool InBody(int x, int y)
        {
            double Xl = (double)(x-Frame.x1)/(double)(Frame.x2-Frame.x1);
            double Yl = (double)(Frame.y2-y)/ (double)(Frame.y2-Frame.y1);
            if ((1-Xl)>=Yl-0.05 && (1-Xl)<=Yl+0.05)
            {
                oldX = x;
                oldY = y;
                return true;
            }
            return false;
        }
    }
}
