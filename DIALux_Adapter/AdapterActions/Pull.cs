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
    public partial class DialUXAdapter : BHoMAdapter
    {
        public virtual List<object> Pull(IEnumerable<object> objects, string tag = "", PullType pullType = PullType.AdapterDefault, ActionConfig actionConfig = null)
        {
            if (!System.IO.File.Exists(System.IO.Path.Combine(FileName + ".stf")))
                return new List<IBHoMObject>();

            if (request != null)
            {
                FilterRequest filterRequest = request as FilterRequest;

                return Read(filterRequest.Type);
            }
            else
                return Read(null);
        }
    }
}