using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeorProg2.Model;

namespace TeorProg2.Property
{
    class FillProp: Properties, IFillProps
    {
        public Color Color { get; set; }
        public FillProp(Color color)
        {
            Color = color;
        }

        public override void Apply(GraphSystem graphSystem)
        {
            graphSystem.FillColor = Color;
        }

        public FillProp Copy()
        {
            return new FillProp(Color);
        }
    }
}
