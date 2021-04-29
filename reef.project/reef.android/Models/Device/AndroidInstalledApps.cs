using System;
using System.Collections.Generic;
using Android.Content.PM;
using reef.shared.Models.Device;

namespace reef.android.Models.Device {
    public class AndroidInstalledApps : InstalledApps {
        public override IList<AppInfo> Get() {
            IList<ApplicationInfo> androidAppInfo = Android.App.Application.Context.PackageManager.GetInstalledApplications(PackageInfoFlags.MatchAll);
            IList<AppInfo> appInfo = new List<AppInfo>();
            foreach (ApplicationInfo info in androidAppInfo) {
                appInfo.Add(new AppInfo(info.LoadLabel(Android.App.Application.Context.PackageManager), info.PackageName));
            }
            return appInfo;
        }
    }
}