using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeorProg2.Model;

namespace TeorProg2.GraphicItems
{
    abstract class GraphItem
    {
        public Frame Frame { get; set; }
        public LocalFrame LocalFrame { get; set; }

        public int oldX;
        public int oldY;
        public GraphItem(Frame frame)
        {
            if (Frame == null)
            {
                Frame = frame;
            }
        }
        public void SetLocalFrame(Frame frame)
        {
            LocalFrame = new LocalFrame((double)(Frame.x1 - frame.x1) / (frame.x2-frame.x1), (double)(Frame.y1 - frame.y1) / (frame.y2-frame.y1), (double)(Frame.x2-Frame.x1) / (frame.x2 - frame.x1), (double)(Frame.y2 - Frame.y1) / (frame.y2 - frame.y1));
        }
        public virtual void ChangeFrame(Frame localFrame)
        {
            Frame = new Frame((int)(localFrame.x1 + (LocalFrame.x1 * (localFrame.x2-localFrame.x1))), (int)(localFrame.y1 + (LocalFrame.y1 * (localFrame.y2 - localFrame.y1))), (int)(Frame.x1 + ((localFrame.x2 - localFrame.x1) * LocalFrame.localWidth)), (int)(Frame.y1+((localFrame.y2 - localFrame.y1) * LocalFrame.localHeight)));
        }
        abstract public void Draw(TeorProg2.Model.GraphSystem graphSystem);

        public abstract Selection CreateSelection();

        abstract public bool InBody(int x, int y);

        public void MoveItem(int x, int y)
        {
            Frame.x1 += (x-oldX);
            Frame.x2 += (x - oldX);
            Frame.y1 += (y-oldY);
            Frame.y2 += (y - oldY);
        }
    }

    public class LocalFrame
    {
        public double x1;
        public double y1;
        public double localWidth;
        public double localHeight;
        public LocalFrame(double x1, double y1, double localWidth, double localHeight)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.localWidth = localWidth;
            this.localHeight = localHeight;
        }
    }
}
