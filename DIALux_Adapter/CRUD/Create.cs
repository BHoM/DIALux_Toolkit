/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
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

using BH.oM.Environment.Elements;
using BH.Engine.Environment;

using System.IO;
using BH.Engine.Adapter;

using BH.oM.Adapter;

namespace BH.Adapter.DIALux
{
    public partial class DIALuxAdapter : BHoMAdapter
    {
        protected override bool ICreate<T>(IEnumerable<T> objects, ActionConfig actionconfig = null)
        {
            StfFile file = new StfFile();

            List<IBHoMObject> bhomObjects = objects.Select(x => (IBHoMObject)x).ToList();
            List<Panel> panels = bhomObjects.Panels();

            List<List<Panel>> panelsAsSpaces = panels.ToSpaces();

            foreach(List<Panel> space in panelsAsSpaces)
                file.Project.Rooms.Add(space.ToDIALux());

            StreamWriter sw = new StreamWriter(FileSettings.GetFullFileName());

            WriteVersion(sw, file.Version);
            WriteProject(sw, file.Project);

            sw.Close();

            return true;
        }

        private void WriteVersion(StreamWriter sw, Version version)
        {
            sw.WriteLine("[VERSION]");
            sw.WriteLine("STFF=" + version.VersionNo);
            sw.WriteLine("Progname=" + version.ProgramName);
            sw.WriteLine("Progvers=" + version.ProgramVersion);
        }

        private void WriteProject(StreamWriter sw, Project project)
        {
            sw.WriteLine("[PROJECT]");
            sw.WriteLine("Name=" + project.Name);
            sw.WriteLine("Date=" + project.Date.ToString("yyyy-MM-dd"));
            sw.WriteLine("Planer=" + project.Planer);
            sw.WriteLine("Description=" + project.Description);
            sw.WriteLine("NrRooms=" + project.Rooms.Count.ToString());
            for (int x = 1; x <= project.Rooms.Count; x++)
                sw.WriteLine("Room" + x.ToString() + "=ROOM.R" + x.ToString());

            for (int x = 1; x <= project.Rooms.Count; x++)
                WriteRoom(sw, project.Rooms[x-1], x);
        }

        private void WriteRoom(StreamWriter sw, Room room, int index)
        {
            sw.WriteLine("[ROOM.R" + index.ToString() + "]");
            sw.WriteLine("Name=" + room.Name);
            sw.WriteLine("Description=" + room.Description);
            sw.WriteLine("Height=" + room.Height);
            sw.WriteLine("NrPoints=" + room.Points.Count.ToString());
            for (int x = 1; x <= room.Points.Count; x++)
                sw.WriteLine("Point" + x.ToString() + "=" + room.Points[x-1].ToDIALux());

            sw.WriteLine("NrStruct=" + room.Structures.Count.ToString());
            //Add structure output here...

            sw.WriteLine("NrLums=" + room.Luminaires.Count.ToString());
            //Add luminaire output here...

            sw.WriteLine("NrFurns=" + room.Furnishings.Count.ToString());
            for (int x = 1; x <= room.Furnishings.Count; x++)
                WriteFurnishings(sw, room.Furnishings[x-1], "ROOM.R" + index.ToString(), x);
        }

        private void WriteFurnishings(StreamWriter sw, Furnishing furnishing, string roomReference, int index)
        {
            furnishing.Reference = roomReference + ".F" + index.ToString();
            string furnIndex = "Furn" + index.ToString();
            sw.WriteLine(furnIndex + "=" + furnishing.Type);
            sw.WriteLine(furnIndex + ".Ref=" + furnishing.Reference);
            sw.WriteLine(furnIndex + ".Rot=" + furnishing.RotationX.ToString() + " " + furnishing.RotationY.ToString() + " " + furnishing.RotationZ.ToString());
            sw.WriteLine(furnIndex + ".Pos=" + furnishing.Position.ToDIALux());
            sw.WriteLine(furnIndex + ".Size=" + furnishing.Width.ToString() + " " + furnishing.Height.ToString() + " " + furnishing.Depth.ToString());
        }
    }
}



