using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeorProg2.Property
{
    class PropList: List<Properties>
    {

        public void Apply(Model.GraphSystem graphSystem)
        {
            for (int i = 0; i < this.Count; i++)
            {
                this[i].Apply(graphSystem);
            }
        }
    }
}
