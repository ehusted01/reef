
#region Using statements

using System;
using System.Collections.Generic;
using reef.shared.Models.Device;
using Android.App.Usage;
using System.Linq;
using Android.Content;
using Android.App;
using Android;
using reef.shared;


#endregion

namespace reef.android.Models.Device
{
    public class AndroidDeviceActivity : DeviceActivity
    {
        /// <summary>
        /// Constructor. Records a single initial query of activity since the past JOB_INTERVAL.
        /// </summary>
        public AndroidDeviceActivity() : base() {
            RecordUsageFrom(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - FishUpdateScheduler.JOB_INTERVAL);
        }

        /// <summary>
        /// Records usage as described in DeviceActivity using "GetActivity" for the activity querying function.
        /// </summary>
        /// <param name="time">the time from which usage will be recorded</param>
        public override void RecordUsageFrom(long time) {
            base.RecordUsage(time, GetActivity);
        }

        /// <summary>
        /// Returns a Dictionary that maps app package names to a ratio representing the fraction of the query duration
        /// that was spent on that app. The query duration is from startTime to now.
        /// </summary>
        /// <param name="startTime">the starting time of the query</param>
        /// <returns>a Dictionary mapping apps to their activity</returns>
        public static IDictionary<String, double> GetActivity(long startTime)
        {
            // Initialize a Dicitonary, get the UsageStatsManager object, and get the current UTC time in milliseconds
            IDictionary<String, UsageStats> activity;
            UsageStatsManager uSM = (UsageStatsManager)Android.App.
                Application.Context.GetSystemService(Context.UsageStatsService);
            long endTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            // Check for permissions
            AppOpsManager appOps = (AppOpsManager)Application.Context
                .GetSystemService(Context.AppOpsService);
            AppOpsManagerMode mode = appOps.CheckOpNoThrow(AppOpsManager.OpstrGetUsageStats,
                    Android.OS.Process.MyUid(), Application.Context.PackageName);
            if (mode != AppOpsManagerMode.Allowed) {
                System.Diagnostics.Debug.WriteLine("NO_PERMISSIONS");
            }

            // Get the usage stats from startTime to now
            activity = uSM.QueryAndAggregateUsageStats(startTime, endTime);

            // Iterate over the returned stats
            IDictionary<String, double> usage = new Dictionary<String, double>();
            foreach (String package in activity.Keys) {
                // Add a mapping in usage from this app to the fraction of time spent on it
                double duration = activity[package].LastTimeStamp - activity[package].FirstTimeStamp;
                usage.Add(package, activity[package].TotalTimeInForeground / duration);
            }

            return usage;
        }
    }

}