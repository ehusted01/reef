using System;

namespace reef.shared.Models.Device {
    /// <summary>
    /// AppInfo represents an application installed on the device.
    /// </summary>
    public class AppInfo {
        public String Name;
        public String Package;

        public AppInfo(String name, String package) {
            Name = name;
            Package = package;
        }
    }
}