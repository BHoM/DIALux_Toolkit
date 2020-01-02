using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using BH.oM.Base;

using BH.oM.Adapter;

namespace BH.Adapter.DIALux
{
    public partial class DialUXAdapter : BHoMAdapter
    {

        protected override IEnumerable<IBHoMObject> IRead(Type type, IList indices = null, ActionConfig actionConfig = null)
        {
            return IRead(type);
        }

        private IEnumerable<IBHoMObject> IRead(Type type = null)
        {
            return new List<BHoMObject>();
        }
    }
}