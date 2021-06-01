using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Content.PM;
using Android.Icu.Util;
using reef.shared.Models.Device;

namespace reef.android.Models.Device {
    public class AndroidInstalledApps : InstalledApps {
        /// <summary>
        /// The list of application installed on the device
        /// </summary>
        private List<AppInfo> Apps;

        /// <summary>
        /// Constructor. Retrieves the installed applications and stores them sorted by decreasing order
        /// of usage in the past week.
        /// </summary>
        public AndroidInstalledApps() {
            Apps = new List<AppInfo>();

            // Contruct an intent that represents the type of applications we would like to fetch
            Intent intent = new Intent(Intent.ActionMain, null);
            intent.AddCategory(Intent.CategoryLauncher);

            // Query for applications that match the constructed intent and store them in apps
            IList<ResolveInfo> apps = Android.App.Application.
                Context.PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchAll);

            // Iterate over apps
            foreach (ResolveInfo info in apps) {
                // Contruct an AppInfo object representing this app and store it in Apps
                AppInfo app = new AppInfo(info.LoadLabel
                    (Android.App.Application.Context.PackageManager), info.ActivityInfo.ApplicationInfo.PackageName);
                Apps.Add(app);
            }

            // Query the usage of the installed applications in the past week and
            // contruct a dictionary mapping them to the fraction of time spent on them
            long weekAgo = DateTimeOffset.UtcNow.AddDays(-7).ToUnixTimeMilliseconds();
            IDictionary<String, double> usage = AndroidDeviceActivity.GetActivity(weekAgo);
            foreach (AppInfo app in Apps) {
                if (!usage.ContainsKey(app.GetPackage())) {
                    usage.Add(app.GetPackage(), 0);
                }
            }

            // Sort the installed applications in Apps
            Apps = Apps.OrderByDescending(a => usage[a.GetPackage()]).ToList();
        }

        /// <summary>
        /// Returns an read-only list of the installed applications as described in InstalledApps.
        /// </summary>
        /// <returns>a list of the installed apps</returns>
        public override IList<AppInfo> Get() {
            return Apps.AsReadOnly();
        }

        /// <summary>
        /// Returns whether or not info is an installed application as described in InstalledApps
        /// </summary>
        /// <param name="info">the app to check</param>
        /// <returns>true if info is installed, false otherwise</returns>
        public override bool IsInstalled(AppInfo info) {
            return Apps.Contains(info);
        }
    }
}