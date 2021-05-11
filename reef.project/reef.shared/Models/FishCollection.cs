using System;

namespace reef.shared.Models {
  /// <summary>
  /// Contains all of the user information
  /// </summary>
  public class FishCollecton {
    public FishCollecton() {
    }

    public int FishCount { get; private set; } = 1;

    public bool FishUpdated = false;

    public void AddFish() {
      FishCount++;
      FishUpdated = true;
    }

    public void RemoveFish() {
      FishCount--;
      if (FishCount < 0) {
        FishCount = 0;
      }
      FishUpdated = true;
    } 
  }
}
