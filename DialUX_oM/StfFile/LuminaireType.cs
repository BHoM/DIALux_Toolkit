using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.oM.DialUX
{
    public class LuminaireType : BHoMObject
    {
        public string Manufacturer { get; set; } = "";
        public string OrderNumber { get; set; } = "";
        public double BoxHeight { get; set; } = 0.0;
        public double BoxWidth { get; set; } = 0.0;
        public double BoxDepth { get; set; } = 0.0;
        public int Shape { get; set; } = 1;
        public double Load { get; set; } = 0.0;
        public double Flux { get; set; } = 0.0;
        public int NumberLamps { get; set; } = 0;
        public int MountingType { get; set; } = 1;
        public string Description { get; set; } = "";
        public string Picture { get; set; } = "";
        public string Model { get; set; } = "";
    }
}
