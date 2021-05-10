using System;

namespace reef.shared.Models.Device {
    /// <summary>
    /// AppInfo represents an application installed on the device.
    /// </summary>
    public class AppInfo {
        private String Name;
        private String Package;

        public AppInfo(String name, String package)
        {
            Name = name;
            Package = package;
        }

        public String GetName() {
            return Name;
        }

        public String GetPackage() {
            return Package;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Package.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is AppInfo)) {
                return false;
            }
            AppInfo app = (AppInfo)obj;
            return this.Name.Equals(app.Name) && this.Package.Equals(app.Package);
        }
    }
}