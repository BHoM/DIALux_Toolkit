using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;

namespace BH.oM.DIALux
{
    public class Version : BHoMObject
    {
        public string VersionNo { get; set; } = "1.0.5";
        public string ProgramName { get; set; } = "BHoM";
        public string ProgramVersion { get; set; } = "2.3.0";
    }
}
