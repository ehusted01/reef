using reef.shared.Models;
using reef.shared.Models.Device;
using System;

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
      Fish.AddFish(GameHost.FishController.GetCommon());
      Fish.AddFish(GameHost.FishController.GetUncommon());
      Fish.AddFish(GameHost.FishController.GetRare());
    }

    public void UpdateFish() {
      // Record usage since we last checked
      DeviceActivity.RecordUsageFrom(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - FishUpdateScheduler.JOB_INTERVAL);

      // Iterate over all of the problem apps to count up usage
      double currUsage = 0;
      double avgUsage = 0;
      foreach (AppInfo info in DeviceActivity.GetProblemApps()) {
        // Increment currUsage by usage we just recorded for this problem app
        currUsage += DeviceActivity.GetPastStats(info, 0);

        // Sum up the usage from the past 7 queries, ignoring entries where we have no data
        int count = 0;
        double sum = 0;
        for (int i = 1; i <= 7; i++) {
          double usage = DeviceActivity.GetPastStats(info, i);
          if (usage != AppActivityLog.NO_DATA) {
            sum += usage;
            count++;
          }
        }

        // If we found a non-zero number of past entries, increment avgUsage by their sum / count
        if (count != 0) {
          avgUsage += sum / count;
        }
      }

      // Get a random common fish from the the FishLibrary
      var feesh = GameHost.FishController.GetCommon();

      // If the user has spent less than 1% of their time on problem apps, give them a fish
      if (currUsage < 0.01) {
          Fish.AddFish(feesh);
      // Otherwise, give them a fish if they spent less time than average on problem apps
      } else if (currUsage < avgUsage) {
        Fish.AddFish(feesh);
      // Otherwise, take away a fish if they spent more time than average on problem apps
      } else if (currUsage > avgUsage) {
        Fish.RemoveFish();
      }
    }
  }
}
