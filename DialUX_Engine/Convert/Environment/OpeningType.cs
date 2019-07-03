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

using BH.oM.DialUX;

namespace BH.Engine.DialUX
{
    public static partial class Convert
    {
        [Description("Convert a BHoM Environment Opening Type into a DialUX Furnishing Type")]
        [Input("openingType", "A BHoM Environment Opening Type to convert")]
        [Output("furnishingType", "A DialUX furnishing type")]
        public static string ToDialUX(this OpeningType openingType)
        {
            switch(openingType)
            {
                case OpeningType.CurtainWall:
                case OpeningType.Glazing:
                case OpeningType.Rooflight:
                case OpeningType.RooflightWithFrame:
                case OpeningType.Window:
                case OpeningType.WindowWithFrame:
                    return "win";
                case OpeningType.Door:
                case OpeningType.VehicleDoor:
                    return "door";
                default:
                    return "";
            }
        }

        [Description("Convert a DialUX Furnishing Type into a BHoM Opening Type")]
        [Input("furnishingType", "A DialUX furnishing type to convert")]
        [Output("openingType", "A BHoM Environment Opening Type")]
        public static OpeningType ToBHoMOpeningType(string furnishingType)
        {
            if (furnishingType == "win")
                return OpeningType.Window;
            else if (furnishingType == "door")
                return OpeningType.Door;
            else
                return OpeningType.Undefined;
        }
    }
}