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

namespace BH.Engine.Adapters.DIALux
{
    public static partial class Convert
    {
        [Description("Converts a BHoM Geometry Point to a DialUX point string, rounded to the specified number of decimal places")]
        [Input("point", "The BHoM Geometry Point to convert")]
        [Input("decimalPlaces", "Define how many decimal places you want the coordinate to contain. Default 3")]
        [Input("fullPoint", "Decide whether to export XYZ coordinates or just XY coordinates. Default false - default to export XY coordinates only")]
        [Output("dialUXPoint", "String representing a DialUX point")]
        public static string ToDialUX(this Point point, int decimalPlaces = 3, bool fullPoint = false)
        {
            double x = Math.Round(point.X, decimalPlaces);
            double y = Math.Round(point.Y, decimalPlaces);
            double z = (fullPoint ? Math.Round(point.Z, decimalPlaces) : 0.0);

            string dialUX = x.ToString() + " " + y.ToString();
            if (fullPoint)
                dialUX += " " + z.ToString();

            return dialUX;
        }

        [Description("Converts a DialUX Point string to a BHoM Geometry Point. DialUX Point should be in the format of X Y Z with spaces between each coordinate. Z coordinate is optional")]
        [Input("dialUXPoint", "The DialUX Point to convert to BHoM")]
        [Output("point", "The converted BHoM geometry point")]
        public static Point FromDialUXPoint(this string dialUXPoint)
        {
            string[] pointParts = dialUXPoint.Split('=')[1].Split(' ');
            if(pointParts.Length < 2)
            {
                BH.Engine.Reflection.Compute.RecordError("That string does not contain enough parts to convert to a BHoM point");
                return null;
            }
            if(pointParts.Length > 3)
            {
                BH.Engine.Reflection.Compute.RecordError("That string contains too many parts to convert to a BHoM point. It should contain 3 numbers separated by spaces and nothing more.");
                return null;
            }

            Point p = new Point();
            if (pointParts.Length > 0)
            {
                try
                {
                    p.X = System.Convert.ToDouble(pointParts[0]);
                }
                catch {
                    BH.Engine.Reflection.Compute.RecordError("Attempting to convert to the X coordinate failed. An error occurred in converting the string part to a double for a BHoM Point. The string part was: " + pointParts[0] + " - please ensure it does not contain any invalid characters");
                    return null;
                }
            }
            if (pointParts.Length > 1)
            {
                try
                {
                    p.Y = System.Convert.ToDouble(pointParts[1]);
                }
                catch
                {
                    BH.Engine.Reflection.Compute.RecordError("Attempting to convert to the Y coordinate failed. An error occurred in converting the string part to a double for a BHoM Point. The string part was: " + pointParts[1] + " - please ensure it does not contain any invalid characters");
                    return null;
                }
            }
            if (pointParts.Length > 2)
            {
                try
                {
                    p.Z = System.Convert.ToDouble(pointParts[2]);
                }
                catch
                {
                    BH.Engine.Reflection.Compute.RecordError("Attempting to convert to the Z coordinate failed. An error occurred in converting the string part to a double for a BHoM Point. The string part was: " + pointParts[2] + " - please ensure it does not contain any invalid characters");
                    return null;
                }
            }

            return p; //Successful conversion
        }
    }
}