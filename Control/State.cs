using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeorProg2.Model;

namespace TeorProg2.Control
{
    abstract class State
    {
        internal EventHandler EventHandler { get;  set; }
        StateStore States;
        public abstract StateType stateType { get; }
        public State(EventHandler eventHandler)
        {
            EventHandler = eventHandler;
        }
        public abstract void LeftMouseDown(int x, int y);
        public abstract void LeftMouseUp(int x, int y);
        public abstract void MouseMove(int x, int y);
        abstract public void Delete();
        abstract public void Escape();
        abstract public void CtrlMouseUp(int x, int y);
        abstract public void Group();
        abstract public void UnGroup();
    }

    public enum StateType
    {
        CreateState,
        DragState,
        SingleSelectState,
        MultiSelectState,
        EmptyState
    }

    class CreateState : State
    {
        public override StateType stateType { get { return StateType.CreateState; } }
        public CreateState(EventHandler eventHandler) : base(eventHandler) 
        { }

        public override void LeftMouseDown(int x, int y)
        {
            EventHandler.Model.Factory.CreateAndGrabItem(x, y);
            EventHandler.Model.GrController.Repaint();

            EventHandler.ActivateState(StateType.DragState);
        }

        public override void LeftMouseUp(int x, int y)
        {

        }

        public override void MouseMove(int x, int y)
        {

        }

        override public void Delete() { }
        override public void Escape() { }
        override public void CtrlMouseUp(int x, int y) { }
        override public void Group() { }
        override public void UnGroup() { }
    }

    class DragState : State
    {
        public override StateType stateType { get { return StateType.DragState; } }
        public DragState(EventHandler eventHandler) : base(eventHandler)
        { }

        public override void LeftMouseDown(int x, int y)
        {
            var select = EventHandler.Model.Factory.Selection.selectionStore.TryGrab(x, y);
            if (select == null)
            {
                EventHandler.Model.Factory.Selection.DeleteSelections();
            }
        }

        public override void LeftMouseUp(int x, int y)
        {
            EventHandler.Model.Factory.Selection.ReleaseSelection();
            EventHandler.Model.GrController.Repaint();
            EventHandler.ActivateState(StateType.SingleSelectState);
        }

        public override void MouseMove(int x, int y)
        {
            EventHandler.Model.Factory.Selection.DragSelectionTo(x, y);
            EventHandler.Model.GrController.Repaint();
        }
        override public void Delete() { }
        override public void Escape() { }
        override public void CtrlMouseUp(int x, int y) { }
        override public void Group() { }
        override public void UnGroup() { }
    }
    class SingleSelectState : State
    {
        public override StateType stateType { get { return StateType.SingleSelectState; } }
        public SingleSelectState(EventHandler eventHandler) : base(eventHandler)
        { }

        public override void LeftMouseDown(int x, int y)
        {
            var select = EventHandler.Model.Factory.Selection.selectionStore.TryGrab(x, y);
            if (select != null)
            {
                EventHandler.ActivateState(StateType.DragState);
            }
            else if (EventHandler.Model.Factory.Selection.TrySelect(x, y, false))
            {
                EventHandler.Model.GrController.Repaint();
            }
            else
            {
                EventHandler.Model.Factory.Selection.DeleteSelections();
                EventHandler.Model.GrController.Repaint();
                EventHandler.ActivateState(StateType.EmptyState);
            }
        }

        public override void LeftMouseUp(int x, int y)
        {
            if (EventHandler.Model.Factory.Selection.TrySelect(x, y, false))
            {
                EventHandler.Model.GrController.Repaint();
            }
        }

        public override void MouseMove(int x, int y)
        {
        }
        override public void Delete() 
        {
            EventHandler.Model.Factory.Selection.DelSelectedItems();
            Escape();
        }
        override public void Escape() 
        {
            EventHandler.Model.Factory.Selection.DeleteSelections();
            EventHandler.Model.GrController.Repaint();
            EventHandler.ActivateState(StateType.EmptyState);
        }
        override public void CtrlMouseUp(int x, int y) 
        {
            EventHandler.Model.Factory.Selection.TrySelect(x, y, true);
            EventHandler.ActivateState(StateType.MultiSelectState);
            EventHandler.Model.GrController.Repaint();
        }
        override public void Group() { }
        override public void UnGroup() 
        {
            EventHandler.Model.Factory.Selection.Ungrouping();
            EventHandler.ActivateState(StateType.MultiSelectState);
            EventHandler.Model.GrController.Repaint();
        }
    }

    class MultiSelectState : State
    {
        public override StateType stateType { get { return StateType.MultiSelectState; } }
        public MultiSelectState(EventHandler eventHandler) : base(eventHandler)
        { }

        public override void LeftMouseDown(int x, int y)
        {
            var select = EventHandler.Model.Factory.Selection.selectionStore.TryGrab(x, y);
            if (select != null)
            {
                EventHandler.Model.Factory.Selection.TrySelect(x, y, false);
                EventHandler.ActivateState(StateType.DragState);
            }
            else
            {
                EventHandler.Model.Factory.Selection.DeleteSelections();
                EventHandler.Model.GrController.Repaint();
                EventHandler.ActivateState(StateType.EmptyState);
            }
        }

        public override void LeftMouseUp(int x, int y)
        {
        }

        public override void MouseMove(int x, int y)
        {

        }
        override public void Delete()
        {
            EventHandler.Model.Factory.Selection.DelSelectedItems();
            Escape();
        }
        override public void Escape()
        {
            EventHandler.Model.Factory.Selection.DeleteSelections();
            EventHandler.Model.GrController.Repaint();
            EventHandler.ActivateState(StateType.EmptyState);
        }
        override public void CtrlMouseUp(int x, int y) 
        {
            EventHandler.Model.Factory.Selection.TrySelect(x, y, true);
            EventHandler.Model.GrController.Repaint();
        }
        override public void Group() 
        {
            EventHandler.Model.Factory.Selection.Grouping();
            EventHandler.ActivateState(StateType.SingleSelectState);
            EventHandler.Model.GrController.Repaint();
        }
        override public void UnGroup() { }
    }

    class EmptyState : State
    {
        public override StateType stateType { get { return StateType.EmptyState; } }
        public EmptyState(EventHandler eventHandler) : base(eventHandler)
        { }

        public override void LeftMouseDown(int x, int y)
        {
            if (EventHandler.Model.Factory.Selection.TrySelect(x, y, false))
            {
                EventHandler.ActivateState(StateType.SingleSelectState);
                EventHandler.Model.GrController.Repaint();
            }
        }

        public override void LeftMouseUp(int x, int y)
        {

        }

        public override void MouseMove(int x, int y)
        {

        }
        override public void Delete() { }
        override public void Escape() { }
        override public void CtrlMouseUp(int x, int y) { }
        override public void Group() { }
        override public void UnGroup() { }
    }

    class StateStore : List<State>
    {
        public StateStore(EventHandler eventHandler)
        {
            Add(new CreateState(eventHandler));
            Add(new DragState(eventHandler));
            Add(new SingleSelectState(eventHandler));
            Add(new EmptyState(eventHandler));
            Add(new MultiSelectState(eventHandler));
        }
        public State this[StateType stateType] { get { return this.First(x => x.stateType == stateType); } }

    }
}
