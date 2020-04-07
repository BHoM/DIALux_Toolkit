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

using BH.oM.Base;
using BH.oM.Geometry;

namespace BH.oM.DIALux
{
    public class Room : BHoMObject
    {
        public virtual double Height { get; set; } = 0.0;
        public virtual string Description { get; set; } = "BHoM Created Room";
        public virtual List<Point> Points { get; set; } = new List<Point>();
        public virtual List<Structure> Structures { get; set; } = new List<Structure>();
        public virtual List<Luminaire> Luminaires { get; set; } = new List<Luminaire>();
        public virtual List<Furnishing> Furnishings { get; set; } = new List<Furnishing>();
        public virtual string SpecificConnectedLoad { get; set; } = "";
        public virtual string MeanLuxWorkingPlane { get; set; } = "";
    }
}
