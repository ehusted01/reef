using System;
using System.Collections.Generic;
using System.Text;
using reef.shared.Models;
using reef.shared.Models.Device;

namespace reef.shared.Controllers {
  public class FishController {
    private IDeviceActivity UserActivity;
    private FishCollecton Fish;

    public FishController(IDeviceActivity activity, FishCollecton fish) {
      UserActivity = activity;
      Fish = fish;
    }

    public void UpdateFish() {
      UserActivity.RecordUsageFrom(0);
      double usage = 0;
      double prevUsage = 0;
      foreach (AppInfo info in UserActivity.GetProblemApps()) {
          usage += UserActivity.GetPastStats(info, 0);
          prevUsage += UserActivity.GetPastStats(info, 1);
      }

      if (usage < prevUsage) {
        Fish.AddFish();
      }
      else if (usage > prevUsage) {
        Fish.RemoveFish();
      }
    }
  }
}
