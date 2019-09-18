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