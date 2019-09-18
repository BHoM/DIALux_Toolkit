using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.oM.DIALux
{
    public class Room : BHoMObject
    {
        public double Height { get; set; } = 0.0;
        public string Description { get; set; } = "BHoM Created Room";
        public List<Point> Points { get; set; } = new List<Point>();
        public List<Structure> Structures { get; set; } = new List<Structure>();
        public List<Luminaire> Luminaires { get; set; } = new List<Luminaire>();
        public List<Furnishing> Furnishings { get; set; } = new List<Furnishing>();
        public string SpecificConnectedLoad { get; set; } = "";
        public string MeanLuxWorkingPlane { get; set; } = "";
    }
}
