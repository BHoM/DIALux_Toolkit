using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using BH.oM.Base;

namespace BH.Adapter.DIALux
{
    public partial class DialUXAdapter : BHoMAdapter
    {

        protected override IEnumerable<IBHoMObject> Read(Type type, IList indices = null)
        {
            return Read(type);
        }

        private IEnumerable<IBHoMObject> Read(Type type = null)
        {
            return new List<BHoMObject>();
        }
    }
}