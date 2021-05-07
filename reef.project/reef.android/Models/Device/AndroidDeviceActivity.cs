
#region Using statements

using System;
using System.Collections.Generic;
using reef.shared.Models.Device;
using Android.App.Usage;
using System.Linq;


#endregion

namespace reef.android.Models.Device
{
    public class AndroidDeviceActivity : IDeviceActivity
    {
        private IDictionary<String, AppActivityLog> deviceActivity;

        public AndroidDeviceActivity()
        {
            deviceActivity = new Dictionary<String, AppActivityLog>();
        }


        public void UpdateLastDay()
        {
            // TODO: 
            //foreach (AppInfo String in Activity.Keys)
            //{
            //    Activity[info].LogUsage(GetAct(info));
            //}
        }
        public void Track(AppInfo info)
        {
            
            AppInfo newApp = new AppInfo(info.Name, info.Package);
            AppActivityLog newActivityLog = new AppActivityLog();
            for (int i = 0; i < 29; i++)
            {
                // fill log
                newActivityLog.LogUsage(i, GetAct(newApp, i));
            }
            deviceActivity.Add(newApp.Package, newActivityLog);
           
            

        }

        public void UnTrack(AppInfo info)
        {
            if (deviceActivity.ContainsKey(info.GetPackage()))
            {
                deviceActivity.Remove(info.GetPackage());
            }
        }
        public bool IsTracked(AppInfo info)
        {
            return deviceActivity.ContainsKey(info.GetPackage());
        }

        public double GetAct(AppInfo info, double daysAgo)
        {
            double minutes = 0;
            IDictionary<String, UsageStats> usageLogs = getPastDayStats((int)daysAgo);
            minutes = usageLogs[info.GetPackage()].TotalTimeInForeground;
            return TimeSpan.FromMilliseconds(minutes).TotalMinutes;
        }

        /// <summary>
        /// gets the activity from a day, this many days ago.
        /// </summary>
        /// <param name="days">
        /// daysAgo >= 0
        /// </param>
        private IDictionary<String, UsageStats> getPastDayStats(int daysAgo)
        {
            IDictionary<String, UsageStats> activity;
            UsageStatsManager uSM = (UsageStatsManager)Android.App.
                Application.Context.GetSystemService("usagestats");
            DateTime day;
            Int64 endTime;

            if (daysAgo == 0)
            {
                day = DateTime.Now;
                endTime = day.Millisecond;
            } else
            {
                day = DateTime.Now.AddDays(-daysAgo);
                endTime = day.AddDays(1).Date.Millisecond;
            }
            Int64 startTime = day.Date.Millisecond;
            
            activity = uSM.QueryAndAggregateUsageStats(startTime, endTime);
            return activity;
        }
    }

}