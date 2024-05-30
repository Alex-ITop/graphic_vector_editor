using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeorProg2.GraphicItems;

namespace TeorProg2.Model
{
    internal interface IModel
    {
        IFactory Factory { get; }
        IGrProperties GrProperties { get; }
        IGrController GrController { get; }
    }

    interface IGrProperties
    {
        IContourProps ContourProps { get; }
        IFillProps FillProps { get; }
    }

    interface IFillProps
    {
        Color Color { get; set; }
    }
    interface IContourProps
    {
        int Width { get; set; }
        Color Color { get; set; }
    }
    interface IGrController
    {
        void SetPort(Graphics graphics, int width, int height);
        void Repaint();
    }

    interface IFactory
    {
        ItemType itemType { get; set; }
        ISelection Selection { get; }
        GraphItem CreateItem(int x, int y);
        void CreateAndGrabItem(int x, int y);
    }

    enum ItemType
    {
        None,
        Line,
        Rectangle,
        Ellipse
    }
}
