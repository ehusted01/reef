#region Using statements
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace reef.shared.Models.Device {
    /// <summary>
    /// DeviceActivity represents the activity of specified problem apps on the device.
    /// </summary>
    public class DeviceActivity {
        /// <summary>
        /// A Dictionary mapping apps to a log of their activity.
        /// </summary>
        private IDictionary<AppInfo, AppActivityLog> deviceActivity;

        /// <summary>
        /// Constructor.
        /// </summary>
        public DeviceActivity() {
            deviceActivity = new Dictionary<AppInfo, AppActivityLog>();
        }

        /// <summary>
        /// Records the usage of the current problem apps since time.
        /// </summary>
        /// <param name="time">the time from which to record usage</param>
        public virtual void RecordUsageFrom(long time) {
            // It is considered invalid to record usage in a non-device-specific instance of DeviceActivity
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Records the usage of the current problem apps since time given a function that
        /// returns activity since a certain time.
        /// </summary>
        /// <param name="time">the time from which to record</param>
        /// <param name="getActivity">the function describing how to get the activity</param>
        public void RecordUsage(long time, Func<long, IDictionary<String, double>> getActivity) {
            // Retrieve the activity and iterate over the problem apps
            IDictionary<String, double> activity = getActivity(time);
            foreach (AppInfo info in deviceActivity.Keys) {
                // If the app was not found in the retrieved activity, log 0 usage
                if (!activity.ContainsKey(info.GetPackage())) {
                    deviceActivity[info].LogUsage(0);
                // Otherwise, log the usage found in activity
                } else {
                    deviceActivity[info].LogUsage(activity[info.GetPackage()]);
                }
            }
        }

        /// <summary>
        /// Start tracking the app, info, as a problem app if it is not already tracked.
        /// </summary>
        /// <param name="info">the new problem app to track</param>
        public void Track(AppInfo info) {
            if (!IsTracked(info)) {
                deviceActivity.Add(info, new AppActivityLog());
            }
        }

        /// <summary>
        /// Untracks the app, info, as a problem app if it is currently tracked.
        /// </summary>
        /// <param name="info">the app to be untracked</param>
        public void UnTrack(AppInfo info) {
            if (IsTracked(info)) {
                deviceActivity.Remove(info);
            }
        }

        /// <summary>
        /// Returns true if the app, info, is currently being tracked. False otherwise.
        /// </summary>
        /// <param name="info">the app that is checked</param>
        /// <returns>True if info is tracked, False otherwise</returns>
        public bool IsTracked(AppInfo info) {
            return deviceActivity.ContainsKey(info);
        }

        /// <summary>
        /// Gets the activity from a query, lastQuery many queries ago.
        /// </summary>
        /// <param name="info">
        /// the app to get the activity of
        /// </param>
        /// <param name="lastQuery">
        /// how many queries ago to get the activity from
        /// </param>
        public double GetPastStats(AppInfo info, int lastQuery) {
            // info must be a tracked problem apps and lastQuery cannot be negative
            if (!IsTracked(info) || lastQuery < 0) {
                throw new ArgumentException();
            }
            return deviceActivity[info].GetUsage(lastQuery);
        }

        /// <summary>
        /// Returns a list of the currently tracked problem apps.
        /// </summary>
        /// <returns>a list of the problem apps</returns>
        public IList<AppInfo> GetProblemApps() {
            return deviceActivity.Keys.ToList();
        }
    }
}
