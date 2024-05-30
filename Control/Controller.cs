using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeorProg2.Model;
using static System.Windows.Forms.AxHost;

namespace TeorProg2.Control
{
    internal class Controller:IController
    {
        public IModel Model { get; set; }
        public IEventHandler EventHandler { get; set; }
        public Controller(IModel model)
        {
            Model= model;
            EventHandler = new EventHandler(Model);
        }
    }

    class EventHandler: IEventHandler        // обработчик событий
    {
        public IModel Model { get; set; }
        StateStore StateStore;
        State State;
        public EventHandler (IModel model)      
        {
            Model = model;
            StateStore = new StateStore(this);
            State = StateStore[StateType.CreateState];
        }
        public void LeftMouseUp(int x, int y)
        {
            State.LeftMouseUp(x, y);
        }

        public void CtrlMouseUp(int x, int y)
        {
            State.CtrlMouseUp(x, y);
        }
        public void LeftMouseDown(int x, int y)
        {
            State.LeftMouseDown(x, y);
        }

        public void MouseMove(int x, int y)
        {
            State.MouseMove(x, y);
        }

        public void Group()
        {
            State.Group();
        }

        public void UnGroup()
        {
            State.UnGroup();
        }

        public void Escape()
        {
            State.Escape();
        }

        public void Delete()
        {
            State.Delete();
        }
        public void ActivateState(StateType stateType)
        {
            State = StateStore[stateType];
        }

    }
}
