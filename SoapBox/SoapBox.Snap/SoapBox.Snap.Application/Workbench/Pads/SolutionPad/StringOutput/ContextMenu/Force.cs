#region "SoapBox.Snap License"
/// <header module="SoapBox.Snap"> 
/// Copyright (C) 2009-2015 SoapBox Automation, All Rights Reserved.
/// Contact: SoapBox Automation Licencing (license@soapboxautomation.com)
/// 
/// This file is part of SoapBox Snap.
/// 
/// SoapBox Snap is free software: you can redistribute it and/or modify it
/// under the terms of the GNU General Public License as published by the 
/// Free Software Foundation, either version 3 of the License, or 
/// (at your option) any later version.
/// 
/// SoapBox Snap is distributed in the hope that it will be useful, but 
/// WITHOUT ANY WARRANTY; without even the implied warranty of
/// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
/// GNU General Public License for more details.
/// 
/// You should have received a copy of the GNU General Public License along
/// with SoapBox Snap. If not, see <http://www.gnu.org/licenses/>.
/// </header>
#endregion
        
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoapBox.Core;
using System.ComponentModel.Composition;
using SoapBox.Protocol.Base;
using SoapBox.Protocol.Automation;

namespace SoapBox.Snap.Application.Workbench.Pads.SolutionPad.StringOutput.ContextMenu
{
    [Export(ExtensionPoints.Workbench.Pads.SolutionPad.StringOutputItem.ContextMenu, typeof(IMenuItem))]
    class Force : AbstractMenuItem
    {
        public Force()
        {
            ID = Extensions.Workbench.Pads.SolutionPad_.StringOutputItem.ContextMenu.Force;
            Header = Resources.Strings.Solution_Pad_StringOutputItem_Force;
            ToolTip = Resources.Strings.Solution_Pad_StringOutputItem_Force_ToolTip;

            SetIconFromBitmap(Resources.Images.On);
        }

        [Import(Services.Solution.RuntimeService, typeof(IRuntimeService))]
        private IRuntimeService runtimeService { get; set; }

        protected override void Run()
        {
            base.Run();
            var di = Context as SoapBox.Snap.Application.StringOutputItem;
            if (di != null)
            {
                var nStringOutput = di.StringOutput.SetForced(new FieldBool(true));
                nStringOutput = nStringOutput.SetForcedValue(runtimeService.GetConstant(FieldDataType.DataTypeEnum.STRING, di.StringOutput.ForcedValue));
                di.StringOutput = nStringOutput;
            }
        }
    }
}
