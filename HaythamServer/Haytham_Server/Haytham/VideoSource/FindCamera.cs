//<copyright file="FindCamera.cs" company="ITU">
//This file is part of Haytham 
//Copyright (C) 2013 Diako Mardanbegi
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
// <author>Diako Mardanbegi</author>
// <email>dima@itu.dk</email>
// Changed by Peter Jurnecka

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using AForge.Video.DirectShow;
using AForge.Video;

namespace Haytham.VideoSource
{
    public class FindCamera
    {
        /// <summary>
        /// <para> DeviceList=|   Deviceinfo 0--|-----|__Name </para>
        /// <para>            |   Deviceinfo 1  |     |__MonikerString</para>
        /// <para>            |                 |     |__index</para>
        /// <para>            |                 |     |__DeviceCapabilityList=|  DeviceCapabilityInfo 0--|----|__FrameSize</para>
        /// <para>            |                 |                             |  DeviceCapabilityInfo 1  |    |__MaxFPS</para>
        /// <para>            |   Deviceinfo n  |                             |                          |</para>
        /// <para>                                                            |                          |</para>
        /// <para>                                                            |                          |</para>
        /// <para>           &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; |  DeviceCapabilityInfo n  |</para>
        /// </summary>
        ///
        public IEnumerable<IVideoSource> DeviceList
        {
            get
            {
                lock (DeviceCache)
                    return DeviceCache.Values;
            }
        }

        private static Dictionary<string, IVideoSource> DeviceCache = new Dictionary<string, IVideoSource>();

        public void Search()
        {
            //AforgeVideoSourceLite.GetDevices(ref DeviceCache);	//FIX: use this if you have problems with device .. it uses only base directshow calls. No device capabilityList
            PSEyeSource.GetDevices(ref DeviceCache);
            AforgeVideoSource.GetDevices(ref DeviceCache);
            FileVideoSource.GetDevices(ref DeviceCache);
            FileVideoSource2.GetDevices(ref DeviceCache);
        }
    }
}