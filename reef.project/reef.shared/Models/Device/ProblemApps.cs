using System;
using System.Collections.Generic;

namespace reef.shared.Models.Device {
    public class ProblemApps {
        private IList<AppInfo> apps;
        public ProblemApps() {
            apps = new List<AppInfo>();
        }
        /// <summary>
        /// Returns a list containing information about the user's problem apps.
        /// </summary>
        public IList<AppInfo> Get() {
            return apps;
        }
        /// <summary>
        /// Adds an app, info, to the user's problem apps.
        /// </summary>
        public void Add(AppInfo info) {
            apps.Add(info);
        }
        /// <summary>
        /// Removes the app, info, from the user's problem apps.
        /// </summary>
        public void Remove(AppInfo info) {
            apps.Remove(info);
        }
    }
}
