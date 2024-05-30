using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeorProg2.GraphicItems
{
    class Group : GraphItem
    {
        public List<GraphItem> Items;
        public Group(List<GraphItem> graphItems) : base(null)
        {
            Items = graphItems.GetRange(0, graphItems.Count);
            GetFrame();
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
    }
}
