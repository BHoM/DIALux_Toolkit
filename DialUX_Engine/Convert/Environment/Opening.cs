using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Geometry;
using BH.oM.Reflection.Attributes;
using System.ComponentModel;
using BH.Engine.Reflection;
using BH.oM.Environment.Elements;
using BH.Engine.Environment;
using BH.Engine.Geometry;

using BH.oM.DIALux;

namespace BH.Engine.DIALux
{
    public static partial class Convert
    {
        [Description("Convert a BHoM Environment Opening into a DialUX Furnishing")]
        [Input("opening", "A BHoM Environment Opening to convert")]
        [Input("roomReference", "A room reference to link this furnishing to")]
        [Output("furnishing", "A DialUX opening represented as a 'furnishing'")]
        public static Furnishing ToDialUX(this Opening opening)
        {
            Furnishing furnishing = new Furnishing();
            furnishing.Type = opening.Type.ToDialUX();
            furnishing.Reference = "";
            furnishing.RotationX = 0;
            furnishing.RotationY = 0;
            furnishing.RotationZ = 0;

            Point centre = opening.Polyline().Centroid();
            centre.Z -= (opening.Polyline().Height() / 2);

            furnishing.Position = centre;
            furnishing.Height = Math.Round(opening.Polyline().Height(), 3);
            furnishing.Width = Math.Round(opening.Polyline().Width(), 3);
            furnishing.Depth = 0;

            return furnishing;
        }
    }
}