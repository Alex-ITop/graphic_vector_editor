using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeorProg2.Model
{
    internal interface ISelection
    {
        SelectionStore selectionStore { get; set; }
        void DragSelectionTo(int x, int y);
        void ReleaseSelection();
        void DeleteSelections();
        bool Grouping();
        bool Ungrouping();
        void DelSelectedItems();
        bool TrySelect(int x, int y, bool Add);
    }
}
