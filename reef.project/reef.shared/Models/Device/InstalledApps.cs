using System;
using System.Collections.Generic;

namespace reef.shared.Models.Device {
    public abstract class InstalledApps {
        /// <summary>
        /// Returns a list containing information about the apps installed on the device.
        /// </summary>
        public abstract IList<AppInfo> Get();
    }
}