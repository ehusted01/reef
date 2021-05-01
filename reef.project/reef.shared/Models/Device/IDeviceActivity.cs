#region Using statements
#endregion

using System.Collections;
using System.Collections.Generic;

namespace reef.shared.Models.Device {
 
    public interface IDeviceActivity {
        /// gets user-time-spent on "apps" starting from 00:00 to current time
        /// <summary>
        /// gets user-time-spent on "apps" starting from 00:00 to current time.
        /// </summary>
        /// <param name="apps">
        /// list of applications to get usage data on.
        /// </param>
        /// <returns>
        /// Activity<<AppInfo>, (hours, minutes, seconds)>.
        /// </returns>
        /// <exception cref="="ObjectNotFoundException"> 
        /// Thrown when "<appInfo>.name" is not installed.
        /// </exception>
        public abstract Hashtable Get(IList<AppInfo> apps);

        /// <summary>
        /// Records the usage of the current problem apps in the last 24 hours.
        /// </summary>
        public abstract void Record();

        /// <summary>
        /// Start tracking the app, info, as a problem app.
        /// </summary>
        /// <param name="info">the new problem app to track</param>
        public abstract void Track(AppInfo info);

        /// <summary>
        /// Untracks the app, info, as a problem app.
        /// </summary>
        /// <param name="info">the app to be untracked</param>
        public abstract void UnTrack(AppInfo info);

        /// <summary>
        /// Returns true if the app, info, is currently being tracked. False otherwise.
        /// </summary>
        /// <param name="info">the app that is checked</param>
        /// <returns>True if info is tracked, False otherwise</returns>
        public abstract bool IsTracked(AppInfo info);
  }
}
