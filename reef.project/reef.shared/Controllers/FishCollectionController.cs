using reef.shared.Models;
using reef.shared.Models.Device;

namespace reef.shared.Controllers {
  public class FishCollectionController {

    public FishCollectionController(DeviceActivity activity, FishCollection fish) {
      DeviceActivity = activity;
      Fish = fish;
    }

    private DeviceActivity DeviceActivity;
    private FishCollection Fish;

    public void AddFish() {
      // Get a random common fish from the the FishLibrary
      var feesh = GameHost.FishController.GetCommon();
      Fish.AddFish(feesh);
    }

    public void UpdateFish() {
      DeviceActivity.RecordUsageFrom(0);
      double usage = 0;
      double prevUsage = 0;
      foreach (AppInfo info in DeviceActivity.GetProblemApps()) {
          usage += DeviceActivity.GetPastStats(info, 0);
          prevUsage += DeviceActivity.GetPastStats(info, 1);
      }

      if (usage < prevUsage) {
        // Get a random common fish from the the FishLibrary
        var feesh = GameHost.FishController.GetCommon();
        Fish.AddFish(feesh); // Add it
      }
      else if (usage > prevUsage) {
        Fish.RemoveFish();
      }
    }
  }
}
