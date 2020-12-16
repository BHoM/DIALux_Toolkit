/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

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

namespace BH.Adapter.DIALux
{
    public static partial class Convert
    {
        [Description("Convert a BHoM Environment Opening Type into a DialUX Furnishing Type")]
        [Input("openingType", "A BHoM Environment Opening Type to convert")]
        [Output("furnishingType", "A DialUX furnishing type")]
        public static string ToDIALux(this OpeningType openingType)
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
        public static OpeningType FromDialUXOpeningType(this string furnishingType)
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