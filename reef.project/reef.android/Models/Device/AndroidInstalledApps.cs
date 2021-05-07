using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Content.PM;
using reef.shared.Models.Device;

namespace reef.android.Models.Device {
    public class AndroidInstalledApps : InstalledApps {
        private List<AppInfo> Apps;

        public AndroidInstalledApps() {
            Apps = new List<AppInfo>();
            IList<double> usage = new List<double>();

            AndroidDeviceActivity activity = new AndroidDeviceActivity();
            Intent intent = new Intent(Intent.ActionMain, null);
            intent.AddCategory(Intent.CategoryLauncher);

            IList<ResolveInfo> apps = Android.App.Application.
                Context.PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchAll);

            foreach (ResolveInfo info in apps) {
                AppInfo app = new AppInfo(info.LoadLabel
                    (Android.App.Application.Context.PackageManager), info.ActivityInfo.PackageName);
                Apps.Add(app);
                usage.Add(activity.GetAct(app));
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