using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeorProg2.Model;

namespace TeorProg2.GraphicItems
{
    class Group : GraphItem
    {
        public List<GraphItem> Items;
        public Group(List<GraphItem> graphItems) : base(null)
        {
            Items = graphItems.GetRange(0, graphItems.Count);
            GetFrame();
            foreach (var item in Items)
            {
                item.SetLocalFrame(Frame);
            }
            ChangeItemsInGroup();
        }

        void GetFrame()
        {
            if (Items.Count > 0)
            {
                Frame = new Frame(Items[0].Frame.x1, Items[0].Frame.y1, Items[0].Frame.x2, Items[0].Frame.y2);
                for (int i = 1; i < Items.Count; i++)
                {
                    Frame.Add(Items[i].Frame);
                }
            }
        }

        public override void Draw(Model.GraphSystem graphSystem)
        {
            foreach(GraphItem item in Items)
            {
                item.Draw(graphSystem);
            }
        }

        public override Selection CreateSelection()
        {
            return new GroupSelection(this);
        }

        public List<GraphItem> Destroy()
        {
            return Items;
        }

        public override bool InBody(int x, int y)
        {
            foreach (var item in Items)
            {
                if (item.InBody(x, y))
                {
                    oldX= x;
                    oldY= y;
                    return true;
                }
            }
            return false;
        }

        public void ChangeItemsInGroup()
        {
            foreach (var item in Items)
            {
                item.ChangeFrame(Frame);
            }
        }

        public override void ChangeFrame(Frame localFrame)
        {
            base.ChangeFrame(localFrame);
            ChangeItemsInGroup();
        }
    }
}
