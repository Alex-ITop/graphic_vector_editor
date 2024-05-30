﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
