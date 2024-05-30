using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TeorProg2.GraphicItems;
using TeorProg2.Property;

namespace TeorProg2
{
    class GraphSystem
    {
        public Pen Pen;
        Pen FramePen = new Pen(Color.Gray);
        Graphics Graphics;
        public Color FillColor = Color.White;
        public GraphSystem(Graphics graphics)
        {
            Graphics = graphics;
            Pen = new Pen(Color.Black);
            Pen.Width = 5;
        }

        public void DrawLine( Frame frame)
        {
            Graphics.DrawLine(Pen, frame.x1, frame.y1, frame.x2, frame.y2);
        }

        public void DrawRect(Frame frame)
        {
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(frame.x1, frame.y1, frame.x2 - frame.x1, frame.y2 - frame.y1);
            Graphics.DrawRectangle(Pen, rect);
            SolidBrush solidBrush = new SolidBrush(FillColor);
            Graphics.FillRectangle(solidBrush, rect);
        }

        public void DrawFrame(Frame frame)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(frame.x1-5, frame.y1-5, frame.x2 - frame.x1+10, frame.y2 - frame.y1+10);
            Graphics.DrawRectangle(FramePen, rectangle);
        }
    }
}
