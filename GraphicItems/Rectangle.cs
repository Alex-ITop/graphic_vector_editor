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
    class Rectangle: Figure
    {
        public Rectangle(Frame frame, PropList propList) : base(frame, propList)
        {

        }

        protected override void DrawGeometry(Model.GraphSystem graphSystem)
        {
            graphSystem.DrawRect( Frame);
        }
        public override Selection CreateSelection()
        {
            return new RectSelection(this);
        }
        public override bool InBody(int x, int y)
        {
            if (x<=Frame.x2 && x>=Frame.x1 && y>=Frame.y1 && y<=Frame.y2) 
            { 
                oldX= x;
                oldY= y;
                return true; 
            }
            return false;
        }
    }
}
