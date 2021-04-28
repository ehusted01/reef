using System;
using System.Collections.Generic;
using Android.Content.PM;
using reef.shared.Models.Device;

namespace reef.android {
  public class AndroidDeviceActivity : IDeviceActivity {
    public AndroidDeviceActivity() {
    }

    public void Get() {
      IList<ApplicationInfo> androidAppInfo = PackageManager.GetInstalledApplications(PackageInfoFlags.MatchAll);
      IList<AppInfo> appInfo = new List<AppInfo>();
      for (ApplicationInfo info : androidAppInfo) {
        appInfo.Add(new AppInfo(info.Name, info.PackageName));
      }
      return appInfo;
    }
}
