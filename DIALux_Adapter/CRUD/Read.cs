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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.Engine.Adapter;
using BH.oM.Adapter;
using BH.oM.Base;
using System.IO;

namespace BH.Adapter.DIALux
{
    public partial class DIALuxAdapter : BHoMAdapter
    {
        protected override IEnumerable<IBHoMObject> IRead(Type type, IList indices = null, ActionConfig actionConfig = null)
        {
            return ReadFullDIALux();
        }

        private IEnumerable<IBHoMObject> ReadFullDIALux()
        {
            List<IBHoMObject> objects = new List<IBHoMObject>();

            if(!System.IO.File.Exists(FileSettings.GetFullFileName()))
            {
                BH.Engine.Reflection.Compute.RecordError("File does not exist to pull from");
                return objects;
            }

            StreamReader sr = new StreamReader(FileSettings.GetFullFileName());

            List<string> dialUXStrings = new List<string>();
            string line = "";
            while ((line = sr.ReadLine()) != null)
                dialUXStrings.Add(line);

            sr.Close();

            dialUXStrings.RemoveRange(0, dialUXStrings.IndexOf("[ROOM.R1]") + 1);

            bool endOfFile = false;
            while(!endOfFile)
            {
                int nextIndex = dialUXStrings.IndexOf(dialUXStrings.Where(x => x.Contains("[ROOM.R")).FirstOrDefault());
                if(nextIndex == -1)
                {
                    nextIndex = dialUXStrings.Count; //End of file
                    endOfFile = true;
                }

                List<string> space = new List<string>();
                for (int x = 0; x < nextIndex; x++)
                    space.Add(dialUXStrings[x]);

                objects.AddRange(space.FromDialUXSpace());

                if (!endOfFile)
                    dialUXStrings.RemoveRange(0, nextIndex + 1);
            }

            return objects;
        }
    }
}
