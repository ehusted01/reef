
#region Using statements

using System;
using System.Collections;
using System.Collections.Generic;
using reef.shared.Models.Device;

#endregion

namespace reef.android.Models.Device {

    public interface IDeviceActivity {
        // interface members
        Hashtable Get(IList<AppInfo> apps);
    }
    public class AndroidDeviceActivity : IDeviceActivity {
        private Dictionary<AppInfo, AppActivityLog> Activity;

        public AndroidDeviceActivity() {
            Activity = new Dictionary<AppInfo, AppActivityLog>();
        }
         public Hashtable Get(IList<AppInfo> apps) {
            throw new NotImplementedException();
        }

        public void Record() {
            foreach (AppInfo info in Activity.Keys) {
                Activity[info].LogUsage(GetActivity(info));
            }
        }
        public void Track(AppInfo info) {
            Activity.Add(info, new AppActivityLog());
        }
        public void UnTrack(AppInfo info) {
            Activity.Remove(info);
        }
        public static double GetActivity(AppInfo info) {
            // This replaces the orignal Get method, simply returning the number of hours
            // a single app was used in the past day.
            throw new NotImplementedException();
        }
    }
}
