using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeorProg2.Property;

namespace TeorProg2.GraphicItems
{
    abstract class Figure: GraphItem
    {
        public PropList PropList;
        public Figure(Frame frame, PropList propList):base(frame)
        {
            PropList = propList;
        }

        public override void Draw(Model.GraphSystem graphSystem)
        {
            PropList.Apply(graphSystem);
            DrawGeometry(graphSystem);
        }
        protected abstract void DrawGeometry(Model.GraphSystem graphSystem);
    }
}
