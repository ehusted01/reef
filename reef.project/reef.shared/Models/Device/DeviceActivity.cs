#region Using statements
#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace reef.shared.Models.Device {
    public class DeviceActivity {

        private IDictionary<AppInfo, AppActivityLog> deviceActivity;
        public DeviceActivity() {
            deviceActivity = new Dictionary<AppInfo, AppActivityLog>();
        }

        /// <summary>
        /// Records the usage of the current problem apps since time.
        /// </summary>
        public virtual void RecordUsageFrom(long time) {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Records the usage of the current problem apps since time given a function that
        /// returns activity since a certain time.
        /// </summary>
        /// <param name="time">the time from which to record</param>
        /// <param name="getActivity">the function describing how to get the activity</param>
        public void RecordUsage(long time, Func<long, IDictionary<String, double>> getActivity) {
            IDictionary<String, double> activity = getActivity(time);
            foreach (AppInfo info in deviceActivity.Keys) {
                if (!activity.ContainsKey(info.GetPackage())) {
                    deviceActivity[info].LogUsage(0);
                } else {
                    deviceActivity[info].LogUsage(activity[info.GetPackage()]);
                }
            }
        }

        /// <summary>
        /// Start tracking the app, info, as a problem app.
        /// </summary>
        /// <param name="info">the new problem app to track</param>
        public void Track(AppInfo info) {
            if (!IsTracked(info)) {
                deviceActivity.Add(info, new AppActivityLog());
            }
        }

        /// <summary>
        /// Untracks the app, info, as a problem app.
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
        /// gets the activity from a day, this many days ago.
        /// </summary>
        /// <param name="info">
        /// the app to get the activity of
        /// </param>
        /// <param name="days">
        /// daysAgo >= 0
        /// </param>
        public double GetPastStats(AppInfo info, int lastQuery) {
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
