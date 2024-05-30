using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeorProg2.Model;

namespace TeorProg2.Control
{
    internal interface IController
    {
        IModel Model { get; set; }
        IEventHandler EventHandler { get;}
    }

    interface IEventHandler
    {
        void LeftMouseUp(int x, int y);
    }
}
