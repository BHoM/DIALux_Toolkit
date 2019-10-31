using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;

using BH.oM.DIALux;
using BH.Engine.DIALux;

using BH.oM.Environment.Elements;
using BH.Engine.Environment;

using System.IO;

namespace BH.Adapter.DIALux
{
    public partial class DialUXAdapter : BHoMAdapter
    {
        protected override bool Create<T>(IEnumerable<T> objects)
        {
            StfFile file = new StfFile();

            List<IBHoMObject> bhomObjects = objects.Select(x => (IBHoMObject)x).ToList();
            List<Panel> panels = bhomObjects.Panels();

            List<List<Panel>> panelsAsSpaces = panels.ToSpaces();

            foreach(List<Panel> space in panelsAsSpaces)
                file.Project.Rooms.Add(space.ToDialUX());

            StreamWriter sw = new StreamWriter(FileName + ".stf");

            WriteVersion(sw, file.Version);
            WriteProject(sw, file.Project);

            sw.Close();

            return true;
        }

        private void WriteVersion(StreamWriter sw, BH.oM.DIALux.Version version)
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
                sw.WriteLine("Point" + x.ToString() + "=" + room.Points[x-1].ToDialUX());

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
            sw.WriteLine(furnIndex + ".Pos=" + furnishing.Position.ToDialUX(fullPoint: true));
            sw.WriteLine(furnIndex + ".Size=" + furnishing.Width.ToString() + " " + furnishing.Height.ToString() + " " + furnishing.Depth.ToString());
        }
    }
}