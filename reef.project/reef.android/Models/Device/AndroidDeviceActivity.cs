
#region Using statements

using System;
using System.Collections.Generic;
using reef.shared.Models.Device;
using Android.App.Usage;
using System.Linq;
using Android.Content;
using Android.App;
using Android;


#endregion

namespace reef.android.Models.Device
{
    public class AndroidDeviceActivity : IDeviceActivity
    {
        private IDictionary<AppInfo, AppActivityLog> deviceActivity;

        public AndroidDeviceActivity()
        {
            deviceActivity = new Dictionary<AppInfo, AppActivityLog>();
        }

        public void RecordUsageFrom(long time)
        {
            IDictionary<String, double> activity = GetActivity(time);
            foreach (AppInfo info in deviceActivity.Keys) {
                if (!activity.ContainsKey(info.GetPackage())) {
                    deviceActivity[info].LogUsage(0);
                } else {
                    deviceActivity[info].LogUsage(activity[info.GetPackage()]);
                }
            }
        }
        public void Track(AppInfo info)
        {
            if (!IsTracked(info)) {
                deviceActivity.Add(info, new AppActivityLog());
            }
        }

        public void UnTrack(AppInfo info)
        {
            if (IsTracked(info))
            {
                deviceActivity.Remove(info);
            }
        }
        public bool IsTracked(AppInfo info)
        {
            return deviceActivity.ContainsKey(info);
        }

        public double GetPastDayStats(AppInfo info, int daysAgo) {
            if (!IsTracked(info) || daysAgo < 0) {
                throw new ArgumentException();
            }
            return deviceActivity[info].GetUsage(daysAgo);
        }

        /// gets user-time-spent on "app" starting from 00:00 to current time
        /// <summary>
        /// gets user-time-spent on "app" starting from 00:00 to current time.
        /// </summary>
        /// <param name="info">
        /// info. of application to get usage data on.
        /// </param>
        /// <param name="daysAgo">
        /// daysAgo >= 0.
        /// </param>
        /// <returns>
        /// Usage time in minutesd (Unix).
        /// </returns>
        /// <exception cref="="Exception"> 
        /// Thrown when "<appInfo>.name" is not installed.
        /// return 0 if there is not activity.
        /// </exception>
        public static IDictionary<String, double> GetActivity(long startTime)
        {
            IDictionary<String, UsageStats> activity;
            UsageStatsManager uSM = (UsageStatsManager)Android.App.
                Application.Context.GetSystemService(Context.UsageStatsService);
            long endTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            AppOpsManager appOps = (AppOpsManager)Application.Context
                .GetSystemService(Context.AppOpsService);
            AppOpsManagerMode mode = appOps.CheckOpNoThrow(AppOpsManager.OpstrGetUsageStats,
                    Android.OS.Process.MyUid(), Application.Context.PackageName);
            if (mode != AppOpsManagerMode.Allowed) {
                System.Diagnostics.Debug.WriteLine("NO_PERMISSIONS");
            }

            activity = uSM.QueryAndAggregateUsageStats(0, endTime);

            IDictionary<String, double> usage = new Dictionary<String, double>();
            foreach (String package in activity.Keys) {
                double duration = activity[package].LastTimeStamp - activity[package].FirstTimeStamp;
                usage.Add(package, activity[package].TotalTimeInForeground / duration);
            }
            return usage;
        }
    }

}