
#region Using statements

using System;
using System.Collections.Generic;
using reef.shared.Models.Device;
using Android.App.Usage;


#endregion

namespace reef.android.Models.Device {
  public class AndroidDeviceActivity : IDeviceActivity {
    private IDictionary<String, UsageStats> activity;
    private UsageStatsManager uSM;

    public AndroidDeviceActivity() {
        uSM = (UsageStatsManager)Android.App.Application.Context
            .GetSystemService("usagestats");
        DateTime today = DateTime.Now;
        Int64 startTime = today.Date.Millisecond;
        Int64 endTime = today.Millisecond;
        activity = uSM.QueryAndAggregateUsageStats(startTime, endTime);
    }

    public void Record() {
        // TODO: 
        //foreach (AppInfo String in Activity.Keys)
        //{
        //    Activity[info].LogUsage(GetAct(info));
        //}
    }

    public void Track(AppInfo info) {
        // TODO: 
    }

    public void UnTrack(AppInfo info) {
        // TODO: 
    }

    public bool IsTracked(AppInfo info) {
        // TODO: 
        return false;
    }

    public double GetAct(AppInfo info) {
        if (activity.ContainsKey(info.Package)) {
            return activity[info.Package].TotalTimeInForeground;
        }
        throw new Exception("App is not installed");
    }
  }
}
