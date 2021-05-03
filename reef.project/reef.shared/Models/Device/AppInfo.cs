using System;

namespace reef.shared.Models.Device {
    /// <summary>
    /// AppInfo represents an application installed on the device.
    /// </summary>
    public class AppInfo {
        public String Name;
        public String Package;
        public Boolean problemApp;

        public AppInfo(String name, String package, Boolean IsProblemApp) {
            Name = name;
            Package = package;
            problemApp = IsProblemApp;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}