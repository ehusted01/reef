using System;
using System.Collections.Generic;

namespace reef.shared.Models.Device {
    /// <summary>
    /// InstalledApps represents all of the installed applications on the device.
    /// </summary>
    public abstract class InstalledApps {
        /// <summary>
        /// Returns a list containing information about the apps installed on the device in descending order of usage.
        /// </summary>
        /// <returns>a list of info about the installed apps</returns>
        public abstract IList<AppInfo> Get();
        /// <summary>
        /// Return true if the app, info, is installed. False otherwise.
        /// </summary>
        /// <param name="info">the app that is checked</param>
        /// <returns>True if info is installed, False otherwise</returns>
        public abstract bool IsInstalled(AppInfo info);
    }
}