using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeorProg2.GraphicItems;

namespace TeorProg2.Model
{
    class Selection
    {
        public GraphItem Item;
        public int grabbedNode = -1;
        public List<System.Drawing.Rectangle> Points = new List<System.Drawing.Rectangle>();
        public Selection(GraphItem graphItem)
        {
            Item = graphItem;
        }
        public bool TryGrab(int x, int y)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                if (Points[i].Contains(x, y) && grabbedNode == -1)
                {
                    grabbedNode = i;
                    return true;
                }
            }
            if (Item.InBody(x, y))
            {
                return true;
            }
            return false;
        }

        public void MoveItem(int x, int y)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                var p = Points[i];
                p.X += x - Item.oldX;
                p.Y += y - Item.oldY;
                Points[i] = p;
            }

            Item.MoveItem(x, y);
            Item.InBody(x, y);
        }

        public virtual bool CommonFrameTryDragTo(int x, int y)
        {
            if (grabbedNode == -1) 
            {
                MoveItem(x, y);
                return true;
            }
            System.Drawing.Rectangle changeSel = Points[grabbedNode];       // определяет захваченную область прямоуг.
            changeSel.X = x-3;
            changeSel.Y = y-3;
            Points[grabbedNode] = changeSel;
            switch (grabbedNode)
            {
                case 0:
                    changeSel = Points[2];
                    changeSel.Y = y - 3;
                    Points[2] = changeSel;
                    changeSel = Points[1];
                    changeSel.X = x - 3;
                    Points[1] = changeSel;
                    Item.Frame.ChangeFrame(Points);
                    return true;
                case 1:
                    changeSel = Points[3];
                    changeSel.Y = y - 3;
                    Points[3] = changeSel;
                    changeSel = Points[0];
                    changeSel.X = x - 3;
                    Points[0] = changeSel;
                    Item.Frame.ChangeFrame(Points);
                    return true;
                case 2:
                    changeSel = Points[0];
                    changeSel.Y = y - 3;
                    Points[0] = changeSel;
                    changeSel = Points[3];
                    changeSel.X = x - 3;
                    Points[3] = changeSel;
                    Item.Frame.ChangeFrame(Points);
                    return true;
                case 3:
                    changeSel = Points[1];
                    changeSel.Y = y - 3;
                    Points[1] = changeSel;
                    changeSel = Points[2];
                    changeSel.X = x - 3;
                    Points[2] = changeSel;
                    Item.Frame.ChangeFrame(Points);
                    return true;
            }
            return false;
        }

        public virtual bool TryDragTo(int x, int y)
        {
            if (CommonFrameTryDragTo(x, y)) {return true; } 
            //if (LocalMarkersTryDragTo(x, y))
            //    return true;
            return false;
        }

        public void ReleaseGrab()   // выпуск захвата
        {
            grabbedNode = -1;
        }
        public void Draw(GraphSystem graphSystem)
        {
            graphSystem.DrawSelections(Points);
        }
    }

    class SelectionStore: List<Selection> 
    {
        public Selection TryGrab(int x, int y) 
        {
            foreach (var select in this)
            {
                if (select.TryGrab(x, y))
                {
                    GrabbedSelection = select;
                    return select;
                }
            }
            return null;
        }
        public Selection GrabbedSelection { get; set; }
        public void Release() 
        {
            GrabbedSelection = null;
            foreach (Selection select in this)
            {
                select.ReleaseGrab();
            }
        }
        public void Draw(GraphSystem graphSystem) 
        {
            foreach (var selection in this)
            {
                selection.Draw(graphSystem);
            }
        }

        public List<GraphItem> GetSelectedItems()
        {
            List<GraphItem> items = new List<GraphItem>();
            foreach (var selection in this)
            {
                items.Add(selection.Item);
            }
            return items;
        }
    }

    class LineSelection: Selection 
    {

        Line line;
        public LineSelection(Line item):base(item) 
        {
            line = item;
            Points.Add(new System.Drawing.Rectangle(line.Frame.x1 - 3, line.Frame.y1 - 3, 6, 6));
            Points.Add(new System.Drawing.Rectangle(line.Frame.x2 - 3, line.Frame.y2 - 3, 6, 6));
        }

        public override bool CommonFrameTryDragTo(int x, int y)
        {
            if (grabbedNode== -1) { MoveItem(x, y); return true; }
            System.Drawing.Rectangle changeSel = Points[grabbedNode];
            changeSel.X = x - 3 ;
            changeSel.Y = y - 3;
            Points[grabbedNode] = changeSel;
            Item.Frame = new Frame(Points[0].X + 3, Points[0].Y + 3, Points[1].X +3, Points[1].Y +3);
            return true;
        }
    }

    class RectSelection: Selection
    {
        Rectangle rectangle;
        public RectSelection(Rectangle item) : base(item)
        {
            rectangle = item;
            Points.Add(new System.Drawing.Rectangle(rectangle.Frame.x1 - 3, rectangle.Frame.y1 - 3, 6, 6));
            Points.Add(new System.Drawing.Rectangle(rectangle.Frame.x1 - 3, rectangle.Frame.y2 - 3, 6, 6));
            Points.Add(new System.Drawing.Rectangle(rectangle.Frame.x2 - 3, rectangle.Frame.y1 - 3, 6, 6));
            Points.Add(new System.Drawing.Rectangle(rectangle.Frame.x2 - 3, rectangle.Frame.y2 - 3, 6, 6));
        }
    }

    class EllipseSelection : Selection
    {
        Ellipse ellipse;
        public EllipseSelection(Ellipse item) : base(item)
        {
            ellipse = item;
            Points.Add(new System.Drawing.Rectangle(ellipse.Frame.x1 - 3, ellipse.Frame.y1 - 3, 6, 6));
            Points.Add(new System.Drawing.Rectangle(ellipse.Frame.x1 - 3, ellipse.Frame.y2 - 3, 6, 6));
            Points.Add(new System.Drawing.Rectangle(ellipse.Frame.x2 - 3, ellipse.Frame.y1 - 3, 6, 6));
            Points.Add(new System.Drawing.Rectangle(ellipse.Frame.x2 - 3, ellipse.Frame.y2 - 3, 6, 6));
        }
    }

    class GroupSelection : Selection
    {
        Group group;
        public GroupSelection(Group item) : base(item)
        {
            group = item;
            Points.Add(new System.Drawing.Rectangle(group.Frame.x1 - 3, group.Frame.y1 - 3, 6, 6));
            Points.Add(new System.Drawing.Rectangle(group.Frame.x1 - 3, group.Frame.y2 - 3, 6, 6));
            Points.Add(new System.Drawing.Rectangle(group.Frame.x2 - 3, group.Frame.y1 - 3, 6, 6));
            Points.Add(new System.Drawing.Rectangle(group.Frame.x2 - 3, group.Frame.y2 - 3, 6, 6));
        }

        public void ChangeItems()
        {
            group.ChangeItemsInGroup();
        }

        public override bool TryDragTo(int x, int y)
        {
            if (CommonFrameTryDragTo(x, y))
            {
                ChangeItems();
                return true;
            }
            return false;
        }
    }

    class SelectionsController: ISelection
    {
        public SelectionStore selectionStore { get; set; }
        public Factory Factory { get; set; }
        public Store Store {get; set; }

        public int Count { get { return selectionStore.Count; } }
        public SelectionsController(SelectionStore selectionStore, Store store, Factory factory)
        {
            this.selectionStore = selectionStore;
            this.Store = store;
            this.Factory = factory;
        }
        public void SelectAndGrab(GraphItem item, int x, int y)
        {
            DeleteSelections();
            Selection selection = item.CreateSelection();
            selectionStore.Add(selection);
            selectionStore.TryGrab(x, y);
        }

        public void DragSelectionTo(int x, int y)
        {
            
            if (selectionStore.GrabbedSelection!=null)
            {
                selectionStore.GrabbedSelection.TryDragTo(x, y);
               
            }
        }

        
        public void ReleaseSelection()
        {
            selectionStore.Release();
        }

        public void DeleteSelections()
        {
            selectionStore.Clear();
        }

        public bool Grouping()
        {
            if (Count > 1)
            {
                List<GraphItem> items = selectionStore.GetSelectedItems();
                Group group = Factory.NewGroup(items);
                selectionStore.Clear();
                selectionStore.Add(group.CreateSelection());
                return true;
            }
            return false;
        }

        public bool Ungrouping()
        {
            if (Count == 1 && selectionStore[0].Item is Group)
            {
                List<GraphItem> items = ((Group)selectionStore[0].Item).Destroy();
                Store.Clear();
                selectionStore.Clear();
                for (int i = 0; i < items.Count; i++)
                {
                    Store.Add(items[i]);
                    selectionStore.Add(items[i].CreateSelection());
                }
                return true;
            }
            return false;
        }

        public void DelSelectedItems()
        {
            List<GraphItem> items = selectionStore.GetSelectedItems();
            Store.Delete(items);
        }

       
        public bool TrySelect(int x, int y, bool Add)
        {
            var grabbedItem = Store.GetItem(x, y);
            if (Add==false) { DeleteSelections(); }
            if (grabbedItem != null)
            {
                selectionStore.Add(grabbedItem.CreateSelection());
                selectionStore.TryGrab(x, y);
                return true;
            }
            return false;
        }

    }
}
