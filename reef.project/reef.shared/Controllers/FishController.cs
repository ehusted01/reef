using System;
using System.Collections.Generic;
using System.Text;
using reef.shared.Models;
using reef.shared.Models.Device;

namespace reef.shared.Controllers {
  public class FishController {
    private DeviceActivity DeviceActivity;
    private FishCollection Fish;

    public FishController(DeviceActivity activity, FishCollection fish) {
      DeviceActivity = activity;
      Fish = fish;
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
        Fish.AddFish();
      }
      else if (usage > prevUsage) {
        Fish.RemoveFish();
      }
    }
  }
}
