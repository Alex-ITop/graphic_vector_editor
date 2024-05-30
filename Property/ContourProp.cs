using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeorProg2.Model;

namespace TeorProg2.Property
{
    class ContourProp:Properties, IContourProps
    {
        public Color Color { get; set; }
        public int Width{get; set; }

        public ContourProp(Color color, int thikness)
        {
            Color = color;
            Width = thikness;
        }

        public override void Apply(GraphSystem graphSystem)
        {
            graphSystem.Pen.Color = Color;
            graphSystem.Pen.Width= Width;
        }

        public ContourProp Copy()
        {
            return new ContourProp(Color, Width);
        }
    }
}
