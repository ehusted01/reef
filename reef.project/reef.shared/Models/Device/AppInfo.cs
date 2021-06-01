using System;

namespace reef.shared.Models.Device {
    /// <summary>
    /// AppInfo represents an application installed on the device.
    /// </summary>
    public class AppInfo {
        /// <summary>
        /// The name of the application.
        /// </summary>
        private String Name;

        /// <summary>
        /// The package name of the application.
        /// </summary>
        private String Package;

        /// <summary>
        /// Constructor. Constructs an AppInfo with name and package.
        /// </summary>
        /// <param name="name">the name of the app</param>
        /// <param name="package">the package name of the app</param>
        public AppInfo(String name, String package) {
            Name = name;
            Package = package;
        }

        /// <summary>
        /// Returns the name of the app.
        /// </summary>
        /// <returns>the name of the app</returns>
        public String GetName() {
            return Name;
        }

        /// <summary>
        /// Returns the package name of the app.
        /// </summary>
        /// <returns>the package name of the app</returns>
        public String GetPackage() {
            return Package;
        }

        /// <summary>
        /// Returns the hashcode for this AppInfo object.
        /// </summary>
        /// <returns>hashcode of this AppInfo</returns>
        public override int GetHashCode() {
            return Name.GetHashCode() ^ Package.GetHashCode();
        }

        /// <summary>
        /// Returns whether this and obj are equal.
        /// </summary>
        /// <param name="obj">the object to check for equality</param>
        /// <returns>True if this == obj, False otherwise</returns>
        public override bool Equals(object obj) {
            if (!(obj is AppInfo)) {
                return false;
            }
            AppInfo app = (AppInfo)obj;
            return this.Name.Equals(app.Name) && this.Package.Equals(app.Package);
        }
    }
}