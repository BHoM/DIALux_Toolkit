using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;

namespace BH.oM.DIALux
{
    public class StfFile : BHoMObject
    {
        public Version Version { get; set; } = new Version();
        public Project Project { get; set; } = new Project();
        public List<LuminaireType> LuminaireTypes { get; set; } = new List<LuminaireType>();
    }
}
