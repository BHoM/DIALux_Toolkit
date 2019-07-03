using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Base;

namespace BH.oM.DialUX
{
    public class Project : BHoMObject
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public string Planer { get; set; } = "00000";
        public string Description { get; set; } = "BHoM Created STF File";
        public List<Room> Rooms { get; set; } = new List<Room>();
    }
}
