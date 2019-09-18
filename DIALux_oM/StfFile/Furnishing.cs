using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.oM.DIALux
{
    public class Furnishing : BHoMObject
    {
        public string Type { get; set; } = "";
        public string Reference { get; set; } = "";
        public Point Position { get; set; } = new Point();
        public double RotationX { get; set; } = 0.0;
        public double RotationY { get; set; } = 0.0;
        public double RotationZ { get; set; } = 0.0;
        public double Height { get; set; } = 0;
        public double Width { get; set; } = 0;
        public double Depth { get; set; } = 0;
    }
}
