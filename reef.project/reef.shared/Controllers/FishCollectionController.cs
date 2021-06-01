using System.Collections.Generic;
using reef.shared.Models;
using reef.shared.Models.Device;
using System;
using reef.shared.Models.Fishes;
using reef.shared.Utils;

namespace reef.shared.Controllers {
  public class FishCollectionController {

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="activity">a reference to the user's DeviceActivity</param>
    /// <param name="fish">a reference to the user's FishCollection</param>
    public FishCollectionController(DeviceActivity activity, FishCollection fish) {
      DeviceActivity = activity;
      Fish = fish;
    }

    /// <summary>
    /// The user's DeviceActivity
    /// </summary>
    private DeviceActivity DeviceActivity;
    
    /// <summary>
    /// The user's FishCollection
    /// </summary>
    private FishCollection Fish;

    /// <summary>
    /// Gets all the fish
    /// </summary>
    /// <returns></returns>
    public List<Fish> GetAll() {
      return Fish.GetFish();
    }

    public void Add(Fish fish) {
      Fish.AddFish(fish);
    }

    /// <summary>
    /// Updates the user's FishCollection based on their activity
    /// </summary>
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

      // Get a random fish from the the FishLibrary
      int rand = Rng.Next(0, 21);
      Fish feesh;
      if (rand < 3) { // 15% chance of rare
        feesh = GameHost.FishController.GetRare();
      } else if (rand < 10) { // 35% chance of uncommon
          feesh = GameHost.FishController.GetUncommon();
      } else { // 50% chance of common
          feesh = GameHost.FishController.GetCommon();
      }

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
