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
using BH.oM.Adapter;
using BH.Engine.Adapter;

namespace BH.Adapter.DIALux
{
    public partial class DIALuxAdapter : BHoMAdapter
    {
        [Description("Produces a DIALux Adapter to allow interopability with DIALux and the BHoM")]
        [Input("fileSettings", "Input fileSettings to get the file name and directory that the DIALux Adapter should use")]
        [Output("adapter", "Adapter to DIALux")]
        public DIALuxAdapter(BH.oM.Adapter.FileSettings fileSettings)
        {
            FileSettings = fileSettings;

            if (!System.IO.Path.HasExtension(fileSettings.FileName) || System.IO.Path.GetExtension(fileSettings.FileName) != ".stf")
            {
                BH.Engine.Reflection.Compute.RecordError("File Name must contain a file extension");
                return;
            }

            AdapterIdName = "DIALux_Adapter";

            // This asks the base Push to only Create the objects.
            m_AdapterSettings.DefaultPushType = oM.Adapter.PushType.CreateOnly;
        }

        private FileSettings FileSettings { get; set; } = null;
    }
}
