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
    public partial class DIALuxAdapter : BHoMAdapter
    {
        [Description("Produces a DIALux Adapter to allow interopability with DIALux and the BHoM")]
        [Input("FileName", "Name of file")]
        [Output("adapter", "Adapter to DIALux")]
        public DIALuxAdapter(string fileName)
        {
            FileName = fileName;

            if (System.IO.Path.HasExtension(FileName) && System.IO.Path.GetExtension(FileName) == ".stf")
            {
                BH.Engine.Reflection.Compute.RecordError("File Name cannot contain a file extension");
                return;
            }

            AdapterIdName = "DIALux_Adapter";

            // This asks the base Push to only Create the objects.
            m_AdapterSettings.DefaultPushType = oM.Adapter.PushType.CreateOnly;
        }

        private string FileName { get; set; } = "";
    }
}
