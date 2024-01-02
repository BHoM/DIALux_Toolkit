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

using BH.Engine;
using BH.oM.Base;

using BH.oM.Base.Attributes;
using System.ComponentModel;
using BH.oM.Data.Requests;
using BH.oM.Adapter;
using BH.Engine.Adapter;

namespace BH.Adapter.DIALux
{
    public partial class DIALuxAdapter : BHoMAdapter
    {
        [Description("Produces a DIALux Adapter to allow interopability with DIALux and the BHoM")]
        [Input("fileSettings", "Input fileSettings to get the file name and directory that the DIALux Adapter should use")]
        [Output("adapter", "Adapter to DIALux")]
        public DIALuxAdapter(BH.oM.Adapter.FileSettings fileSettings)
        {
            FileSettings = fileSettings;

            if (!System.IO.Path.HasExtension(fileSettings.FileName) || System.IO.Path.GetExtension(fileSettings.FileName) != ".stf")
            {
                BH.Engine.Base.Compute.RecordError("File Name must contain a file extension");
                return;
            }

            // This asks the base Push to only Create the objects.
            m_AdapterSettings.DefaultPushType = oM.Adapter.PushType.CreateOnly;
        }

        private FileSettings FileSettings { get; set; } = null;
    }
}




