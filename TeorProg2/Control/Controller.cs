using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeorProg2.Model;

namespace TeorProg2.Control
{
    internal class Controller:IController
    {
        public IModel Model { get; set; }
        public IEventHandler EventHandler { get; set; }
        public Controller(IModel model)
        {
            Model= model;
            EventHandler = new EventHandler(this);
        }
    }

    class EventHandler:IEventHandler
    {
        IModel Model { get; set; }
        public EventHandler(IController controller)
        {
            Model = controller.Model;
        }
        public void LeftMouseUp(int x, int y)
        {
            Model.Factory.CreateItem(x, y);
            Model.GrController.Repaint();
        }
    }
}
