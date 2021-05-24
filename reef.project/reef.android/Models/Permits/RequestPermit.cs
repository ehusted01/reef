using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace reef.android.Models.Permits {
  public class RequestPermit {
    public RequestPermit() {
    }

    public async Task<PermissionStatus> CheckAndRequestLocationPermission() {
      var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

      if (status == PermissionStatus.Granted)
        return status;

      if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS) {
        // Prompt the user to turn on in settings
        // On iOS once a permission has been denied it may not be requested again from the application
        return status;
      }

      if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>()) {
        // Prompt the user with additional information as to why the permission is needed
      }

      status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

      return status;
    }
  }
}
