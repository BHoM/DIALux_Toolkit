using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Data.Requests;
using BH.oM.Adapter;
using BH.oM.Base;
using System.Reflection;

namespace BH.Adapter.DIALux
{
    public partial class DIALuxAdapter : BHoMAdapter
    {
        public override IEnumerable<object> Pull(IRequest request, PullType pullType = PullType.AdapterDefault, ActionConfig actionConfig = null)
        {
            if (!System.IO.File.Exists(System.IO.Path.Combine(FileName + ".stf")))
                return new List<IBHoMObject>();

            if (request != null)
            {
                FilterRequest filterRequest = request as FilterRequest;
                return IRead(filterRequest.Type);
            }
            else
                return IRead(null);
        }
    }
}