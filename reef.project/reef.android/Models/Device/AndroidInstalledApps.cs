using System;
using System.Collections.Generic;
using Android.Content.PM;
using reef.shared.Models.Device;

namespace reef.android.Models.Device {
    public class AndroidInstalledApps : InstalledApps {
        private List<AppInfo> Apps;
        public AndroidInstalledApps() {
            IList<ApplicationInfo> androidAppInfo = Android.App.Application.Context.PackageManager.GetInstalledApplications(PackageInfoFlags.MatchAll);
            Apps = new List<AppInfo>();
            foreach (ApplicationInfo info in androidAppInfo) {
                Apps.Add(new AppInfo(info.LoadLabel(Android.App.Application.Context.PackageManager), info.PackageName));
            }
        }
        public override IList<AppInfo> Get() {
            return Apps.AsReadOnly();
        }
        public override bool IsInstalled(AppInfo info) {
            return Apps.Contains(info);
        }
    }
}