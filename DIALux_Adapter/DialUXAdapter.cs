using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.Engine;
using BH.oM.Base;

using BH.oM.Reflection.Attributes;
using System.ComponentModel;
using BH.oM.Data.Requests;

namespace BH.Adapter.DIALux
{
    public partial class DialUXAdapter : BHoMAdapter
    {
        [Description("Produces an DIALux Adapter to allow interopability with DIALux and the BHoM")]
        [Input("fileName", "Name of file")]
        [Output("adapter", "Adapter to DIALux")]
        public DialUXAdapter(string fileName)
        {
            FileName = fileName;

            if (System.IO.Path.HasExtension(FileName) && System.IO.Path.GetExtension(FileName) == ".stf")
            {
                BH.Engine.Reflection.Compute.RecordError("File Name cannot contain a file extension");
                return;
            }

            AdapterIdName = "DialUX_Adapter";
 /*           Config.UseAdapterId = false;        //Set to true when NextId method and id tagging has been implemented
        }

        public override List<IObject> Push(IEnumerable<IObject> objects, String tag = "", Dictionary<String, object> config = null)
        {
            bool success = true;

            MethodInfo methodInfos = typeof(Enumerable).GetMethod("Cast");
            foreach (var typeGroup in objects.GroupBy(x => x.GetType()))
            {
                MethodInfo mInfo = methodInfos.MakeGenericMethod(new[] { typeGroup.Key });
                var list = mInfo.Invoke(typeGroup, new object[] { typeGroup });
                success &= Create(list as dynamic);
            }

            return success ? objects.ToList() : new List<IObject>();
        }

        public override IEnumerable<object> Pull(IRequest request, Dictionary<string, object> config = null)
        {
            if (!System.IO.File.Exists(System.IO.Path.Combine(FileName + ".stf")))
                return new List<IBHoMObject>();

            if (request != null)
            {
                FilterRequest filterRequest = request as FilterRequest;

                return Read(filterRequest.Type);
            }
            else
                return Read(null); */
        }

        private string FileName { get; set; } = "";
    }
}
