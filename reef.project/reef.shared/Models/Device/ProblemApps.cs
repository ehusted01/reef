using System;
using System.Collections.Generic;

namespace reef.shared.Models.Device {
    public abstract class ProblemApps {
        /// <summary>
        /// Returns a list containing information about the user's problem apps.
        /// </summary>
        public abstract IList<AppInfo> Get();
        /// <summary>
        /// Adds an app, info, to the user's problem apps.
        /// </summary>
        public abstract void Add(AppInfo info);
        /// <summary>
        /// Removes the app, info, from the user's problem apps.
        /// </summary>
        public abstract void Remove(AppInfo info);
    }
}
