using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.Engine;
using BH.oM.Base;
using System.Reflection;

using BH.oM.Reflection.Attributes;
using System.ComponentModel;
using BH.oM.Data.Requests;

namespace BH.Adapter.DialUX
{
    public partial class DialUXAdapter : BHoMAdapter
    {
        [Description("Specify XML file and properties for data transfer")]
        [Input("xmlFileName", "Name of XML file")]
        [Input("xmlDirectoryPath", "Path to XML file")]
        [Input("exportType", "Specify whether the file is TAS or IES specific")]
        [Input("exportDetail", "Define what you want to include in the export, for example 'Spaces'")]
        [Output("adapter", "Adapter to XML")]
        public DialUXAdapter(string fileName)
        {
            FileName = fileName;

            if (System.IO.Path.HasExtension(FileName) && System.IO.Path.GetExtension(FileName) == ".stf")
            {
                BH.Engine.Reflection.Compute.RecordError("File Name cannot contain a file extension");
                return;
            }

            AdapterId = "DialUX_Adapter";
            Config.MergeWithComparer = false;   //Set to true after comparers have been implemented
            Config.ProcessInMemory = false;
            Config.SeparateProperties = false;  //Set to true after Dependency types have been implemented
            Config.UseAdapterId = false;        //Set to true when NextId method and id tagging has been implemented
        }

        public override List<IObject> Push(IEnumerable<IObject> objects, String tag = "", Dictionary<String, object> config = null)
        {
            bool success = true;

            MethodInfo methodInfos = typeof(Enumerable).GetMethod("Cast");
            foreach (var typeGroup in objects.GroupBy(x => x.GetType()))
            {
                MethodInfo mInfo = methodInfos.MakeGenericMethod(new[] { typeGroup.Key });
                var list = mInfo.Invoke(typeGroup, new object[] { typeGroup });
                success &= Create(list as dynamic, false);
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
                return Read(null);
        }

        private string FileName { get; set; } = "";
    }
}
