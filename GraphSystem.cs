using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TeorProg2.GraphicItems;
using TeorProg2.Property;

namespace TeorProg2.Model
{
    class GraphSystem
    {
        public Pen Pen;
        Pen SelectionPen = new Pen(Color.Gray);
        Graphics Graphics;
        public Color FillColor = Color.White;
        public GraphSystem(Graphics graphics)
        {
            Graphics = graphics;
            Pen = new Pen(Color.Black);
        }

        public void DrawLine( Frame frame)
        {
            Graphics.DrawLine(Pen, frame.x1, frame.y1, frame.x2, frame.y2);
        }

        public void DrawRect(Frame frame)
        {
            System.Drawing.Point[] rect = { new System.Drawing.Point(frame.x1, frame.y1), new System.Drawing.Point(frame.x1, frame.y2), new System.Drawing.Point(frame.x2, frame.y2), new System.Drawing.Point(frame.x2, frame.y1) };
            Graphics.DrawPolygon(Pen, rect);
            SolidBrush solidBrush = new SolidBrush(FillColor);
            Graphics.FillPolygon(solidBrush, rect);
        }

        public void DrawEllipse(Frame frame)
        {
            Graphics.DrawEllipse(Pen, frame.x1, frame.y1, frame.x2-frame.x1, frame.y2- frame.y1);
            SolidBrush solidBrush = new SolidBrush(FillColor);
            Graphics.FillEllipse(solidBrush, frame.x1, frame.y1, frame.x2 - frame.x1, frame.y2 - frame.y1);
        }

        public void DrawSelections(List<System.Drawing.Rectangle> points)
        {
            foreach (var p in points)
            {
                Graphics.DrawRectangle(SelectionPen, p);
            }
        }

        public void Clear()
        {
            Graphics.Clear(Color.White);
        }
    }
}
