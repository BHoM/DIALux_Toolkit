using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.oM.DialUX
{
    public class Structure : BHoMObject
    {
        public string Type { get; set; } = "";
        public Point Position { get; set; } = new Point();
        public double RotationX { get; set; } = 0.0;
        public double RotationY { get; set; } = 0.0;
        public double RotationZ { get; set; } = 0.0;
        public Luminaire LuminaireStructure { get; set; } = new Luminaire();
    }
}
