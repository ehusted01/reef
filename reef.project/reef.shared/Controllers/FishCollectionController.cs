﻿using System.Collections.Generic;
using reef.shared.Models;
using reef.shared.Models.Device;
using reef.shared.Models.Fishes;
using reef.shared.Utils;

namespace reef.shared.Controllers {
  public class FishCollectionController {

    public FishCollectionController(DeviceActivity activity, FishCollection fish) {
      DeviceActivity = activity;
      Fish = fish;
    }

    private DeviceActivity DeviceActivity;
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

    public void UpdateFish() {
      DeviceActivity.RecordUsageFrom(0);
      double usage = 0;
      double prevUsage = 0;
      foreach (AppInfo info in DeviceActivity.GetProblemApps()) {
          usage += DeviceActivity.GetPastStats(info, 0);
          prevUsage += DeviceActivity.GetPastStats(info, 1);
      }

      if (usage < prevUsage) { 
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
        Fish.AddFish(feesh); // Add it
      }
      else if (usage > prevUsage) {
        Fish.RemoveFish();
      }
    }
  }
}
