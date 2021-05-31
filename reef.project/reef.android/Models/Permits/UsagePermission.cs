using System;
using Xamarin.Essentials;
using System.Threading.Tasks;
using static Xamarin.Essentials.Permissions;
using Android.Provider;
using Android.Content;

namespace reef.android.Models.Permits {
  public class UsagePermission : BasePermission {
    // This method checks if current status of the permission
    public override Task<PermissionStatus> CheckStatusAsync() {
      throw new NotImplementedException();
    }

    // This method is optional and a PermissionException is often thrown if a permission is not declared
    public override void EnsureDeclared() {
      throw new NotImplementedException();
    }

    // Requests the user to accept or deny a permission
    public override Task<PermissionStatus> RequestAsync() {
      throw new NotImplementedException();
    }

    public override bool ShouldShowRationale() {
      return true;
    }

    public void SettingsPrompt()
        {
            Intent intent = new Intent(Settings.ActionUsageAccessSettings);
            intent.SetFlags(ActivityFlags.NewTask);
            Android.App.Application.Context.StartActivity(intent);
        }
  }
}
