using reef.shared;
using reef.android.Models.Device;
using reef.shared.Config;

namespace reef.android {
  public class AndroidHost : GameHost {

    public AndroidHost()
      : base() {
    }

    protected override void Initialize() {
      // TODO: Add your initialization logic here
      // Use our device-specific implementation of these apps
      InstalledApps = new AndroidInstalledApps();
      DeviceActivity = new AndroidDeviceActivity();
      GameIO = new AndroidIO();
      Content.RootDirectory = "Content/bin/Android/Content/"; // Set our root directory
      base.Initialize();
    }
  }
}
