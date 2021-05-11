#region Using statements
#endregion

using System.Collections;
using System.Collections.Generic;

namespace reef.shared.Models.Device {
    public interface IDeviceActivity
    {
        /// <summary>
        /// Records the usage of the current problem apps since time.
        /// </summary>
        public abstract void RecordUsageFrom(long time);

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

        /// <summary>
        /// gets the activity from a day, this many days ago.
        /// </summary>
        /// <param name="info">
        /// the app to get the activity of
        /// </param>
        /// <param name="days">
        /// daysAgo >= 0
        /// </param>
        public double GetPastDayStats(AppInfo info, int daysAgo);

        public IList<AppInfo> GetProblemApps();
    }
}
