using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.oM.DIALux
{
    public class Luminaire : BHoMObject
    {
        public string Type { get; set; } = "";
        public double RotationX { get; set; } = 0.0;
        public double RotationY { get; set; } = 0.0;
        public double RotationZ { get; set; } = 0.0;
        public Vector Extends { get; set; } = new Vector();

        public LuminaireType LuminaireType { get; set; } = new LuminaireType();
    }
}
