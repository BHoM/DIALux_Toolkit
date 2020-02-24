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

using BH.oM.DIALux;

namespace BH.Engine.DIALux
{
    public static partial class Convert
    {
        [Description("Convert a collection of BHoM Environment Panels that represent a space into a DialUX room")]
        [Input("panelsAsSpace", "A collection of Environment Panels which represent a single space and provide a watertight geometric floorplate")]
        [Output("room", "A DialUX room")]
        public static Room ToDialUX(this List<Panel> panelsAsSpace)
        {
            Room room = new Room();

            room.Name = panelsAsSpace.ConnectedSpaceName();

            Polyline floor = panelsAsSpace.FloorGeometry();
            room.Points = floor.DiscontinuityPoints();

            room.Height = Math.Round(panelsAsSpace.Max(x => x.Height()), 3);

            foreach(Panel p in panelsAsSpace)
            {
                foreach (Opening o in p.Openings)
                    room.Furnishings.Add(o.ToDialUX());
            }

            return room;
        }
    }
}