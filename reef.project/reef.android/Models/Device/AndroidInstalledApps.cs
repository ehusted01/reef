using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content.PM;
using reef.shared.Models.Device;

namespace reef.android.Models.Device {
    public class AndroidInstalledApps : InstalledApps {
        private List<AppInfo> Apps;

        public AndroidInstalledApps() {
            IList<ApplicationInfo> androidAppInfo = Android.App.Application.
                Context.PackageManager.GetInstalledApplications(PackageInfoFlags.MatchAll);
            Apps = new List<AppInfo>();
            IList<double> usage = new List<double>();
            AndroidDeviceActivity activity = new AndroidDeviceActivity();
            foreach (ApplicationInfo info in androidAppInfo) {
                AppInfo app = new AppInfo(info.LoadLabel
                    (Android.App.Application.Context.PackageManager), info.PackageName);
                Apps.Add(app);
                usage.Add(activity.GetAct(app, 0));
            }
            Apps = Apps.OrderByDescending(a => usage[Apps.IndexOf(a)]).ToList();
        }
        public override IList<AppInfo> Get() {
            return Apps.AsReadOnly();
        }
        public override bool IsInstalled(AppInfo info) {
            return Apps.Contains(info);
        }
    }
}