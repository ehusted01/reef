using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Microsoft.Xna.Framework;
using Xamarin.Essentials;
using reef.android.Models.Permits;

namespace reef.android {

  [Activity(
    Label = "@string/app_name",
    MainLauncher = true,
    Icon = "@drawable/icon",
    AlwaysRetainTaskState = true,
    LaunchMode = LaunchMode.SingleInstance,
    ScreenOrientation = ScreenOrientation.FullUser,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize
  )]
  public class ReefActivity : AndroidGameActivity {
    private AndroidHost game;
    private View view;

    protected override void OnCreate(Bundle bundle) {
      base.OnCreate(bundle);
      Platform.Init(this, bundle); // Init the Xamarin.Essentials permissions

      game = new AndroidHost();
      view = game.Services.GetService(typeof(View)) as View;

      SetContentView(view);

      game.Run();
    }

    protected override void OnResume() {
      game.FishController?.UpdateFish();
      base.OnResume();
    }

    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults) {
      Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
      base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    }
  }
}
