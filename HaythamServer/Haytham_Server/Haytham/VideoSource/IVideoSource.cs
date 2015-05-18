//<copyright file="IVideoSource.cs" company="ITU">
//This file is part of Haytham 
//Copyright (C) 2014 Peter Jurnecka
// ------------------------------------------------------------------------
//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program.  If not, see <http://www.gnu.org/licenses/>.
// ------------------------------------------------------------------------
// </copyright>
// <author>Peter Jurnecka</author>
// <email>ijurnecka@fit.vutbr.cz</email>

using System.Collections.Generic;

namespace Haytham.VideoSource
{
	public interface IVideoSource
	{
		string Name { get; }
      
		IEnumerable<DeviceCapabilityInfo> Capabilities { get; }
		DeviceCapabilityInfo SelectedCap { get; set; }
		System.Drawing.Size VideoSize { get; }
		bool HasSettings { get; }
		bool IsRunning { get; }

		void ShowSettings();
		void Start();
		void Stop();

		event AForge.Video.NewFrameEventHandler NewFrame;
	}
}
