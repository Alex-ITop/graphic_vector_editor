using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeorProg2.GraphicItems;
using TeorProg2.Property;

namespace TeorProg2.Model
{
    class Model : IModel
    {
        private Factory factory;
        private Scene scene;
        private GrPropChannel grPropChannel;
        private GrController grController;
        public IFactory Factory { get { return factory as IFactory; } }
        public IGrProperties GrProperties { get { return grPropChannel as IGrProperties; } }
        public IGrController GrController { get { return grController as IGrController; } }
        public GraphSystem graphSystem;
        public Store store;

        public Model()
        {
            store= new Store();
            scene = new Scene(graphSystem, store);
            factory = new Factory(store, scene.Selections);
            grPropChannel = new GrPropChannel(factory);                    
            grController = new GrController(scene);
        }
    }

    class Factory:IFactory
    {
        Store Store;
        private SelectionsController SelectionsController;
        public ISelection Selection { get { return SelectionsController as ISelection; } }
        public ItemType itemType { get; set; }
        public ContourProp ContourProp { get; set; } = new ContourProp(Color.Black, 2);
        public FillProp FillProp { get; set; } = new FillProp(Color.Empty);
        public Factory(Store store, SelectionStore selections) 
        {
            Store= store;
            SelectionsController= new SelectionsController(selections, store, this);
        }
        public GraphItem CreateItem(int x, int y)
        {
            Frame frame;
            PropList propList;
            switch (itemType)
            {
                case ItemType.Line:
                    frame = new Frame(x, y, x+50, y+50);
                    propList = new PropList();
                    propList.Add(ContourProp.Copy());
                    var line = new Line(frame, propList);
                    return line;
                case ItemType.Rectangle:
                    frame = new Frame(x, y, x+50, y+50);
                    propList = new PropList();
                    propList.Add(ContourProp.Copy());
                    propList.Add(FillProp.Copy());
                    var rectangle = new GraphicItems.Rectangle(frame, propList);
                    return rectangle;
                case ItemType.Ellipse:
                    frame = new Frame(x, y, x + 111, y + 50);
                    propList = new PropList();
                    propList.Add(ContourProp.Copy());
                    propList.Add(FillProp.Copy());
                    var ellipse = new GraphicItems.Ellipse(frame, propList);
                    return ellipse;
            }
            return null;
            
        }

        public void CreateAndGrabItem(int x, int y)
        { 
            GraphItem item = CreateItem(x, y);          
            if (item != null) 
            {
                Store.Add(item);
                SelectionsController.SelectAndGrab(item, x, y);
            }
        }

        public Group NewGroup(List<GraphItem> items)
        {
            Group group = new Group(items);
            for (int i = 0; i < items.Count; i++)
            {
                Store.Remove(items[i]);
            }
            Store.Add(group);
            return group;
        }

    }

    class Store: List<GraphicItems.GraphItem>
    {
        public void Delete(List<GraphItem> items)
        {
            foreach (var item in items)
            {
                this.Remove(item);
            }
        }

        public GraphItem GetItem(int x, int y)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].InBody(x, y))
                {
                    return this[i];
                }
            }
            return null;
        }
    }

    class GrController:IGrController
    {
        public Scene scene;
        public GraphSystem graphSystem;

        public GrController(Scene scene)
        {
            this.scene = scene;
        }

        public void SetPort(Graphics graphics, int width, int height)
        {
            graphSystem = new GraphSystem(graphics);
            scene.GraphSystem = graphSystem;       
        }

        public void Repaint()
        {
            scene.Repaint();
        }
    }

    class Scene
    {
        public Store Store;
        public GraphSystem GraphSystem { get; set; }

        public SelectionStore Selections = new SelectionStore();
        public Scene(GraphSystem GraphSystem, Store store) 
        { 
            Store= store;
            this.GraphSystem = GraphSystem;
        }

        public void Repaint()
        {
            GraphSystem.Clear();
            foreach (var item in Store)
            {
                item.Draw(GraphSystem);
            }
            Selections.Draw(GraphSystem);
        }
    }

    class GrPropChannel:IGrProperties
    {
        public IContourProps ContourProps { get; }
        public IFillProps FillProps { get;}
        Factory factory;

        public GrPropChannel(Factory factory)
        {
            this.factory = factory;
            this.ContourProps = factory.ContourProp;
            this.FillProps = factory.FillProp;
        }

        public void ApplyProps()
        {
            factory.ContourProp.Color = ContourProps.Color;
            factory.ContourProp.Width = ContourProps.Width;
            factory.FillProp.Color = FillProps.Color;
        }
    }
}
