using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Content.PM;
using Android.Icu.Util;
using reef.shared.Models.Device;

namespace reef.android.Models.Device {
    public class AndroidInstalledApps : InstalledApps {
        private List<AppInfo> Apps;

        public AndroidInstalledApps() {
            Apps = new List<AppInfo>();

            Intent intent = new Intent(Intent.ActionMain, null);
            intent.AddCategory(Intent.CategoryLauncher);

            IList<ResolveInfo> apps = Android.App.Application.
                Context.PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchAll);

            foreach (ResolveInfo info in apps) {
                AppInfo app = new AppInfo(info.LoadLabel
                    (Android.App.Application.Context.PackageManager), info.ActivityInfo.ApplicationInfo.PackageName);
                Apps.Add(app);
            }

            long yesterday = DateTimeOffset.UtcNow.AddDays(-1).ToUnixTimeMilliseconds();
            
            IDictionary<String, double> usage = AndroidDeviceActivity.GetActivity(yesterday);
            foreach (AppInfo app in Apps) {
                if (!usage.ContainsKey(app.GetPackage())) {
                    usage.Add(app.GetPackage(), 0);
                }
            }

            Apps = Apps.OrderByDescending(a => usage[a.GetPackage()]).ToList();
        }
        public override IList<AppInfo> Get() {
            return Apps.AsReadOnly();
        }
        public override bool IsInstalled(AppInfo info) {
            return Apps.Contains(info);
        }
    }
}