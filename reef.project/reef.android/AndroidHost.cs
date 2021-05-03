using reef.shared;
using reef.android.Models.Device;

namespace reef.android {
  public class AndroidHost : GameHost {

    public AndroidHost()
      : base() {
    }

    protected override void Initialize() {
      base.Initialize();
      // TODO: Add your initialization logic here
      // Use our device-specific implementation of these apps
      // InstalledApps = new AndroidInstalledApps();
      DeviceActivity = new AndroidDeviceActivity();
    }
  }
}
