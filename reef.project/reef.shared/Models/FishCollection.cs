using System;

namespace reef.shared.Models {
  /// <summary>
  /// Contains all of the user information
  /// </summary>
  public class FishCollection {
    public FishCollection() {
    }

    /// <summary>
    /// The default # of fish we start with
    /// </summary>
    public const int DefaultFishCount = 1;

    /// <summary>
    /// The current # of fish we have
    /// </summary>
    public int FishCount { get; private set; } = DefaultFishCount;

    /// <summary>
    /// When flagged as true, our fish collection has been modified
    /// </summary>
    public bool FishUpdated = false;

    /// <summary>
    /// Add a fish to this collection
    /// </summary>
    public void AddFish() {
      FishCount++;
      FishUpdated = true;
    }

    /// <summary>
    /// Remove a fish from this collection
    /// </summary>
    public void RemoveFish() {
      FishCount--;
      if (FishCount < 0) {
        FishCount = 0;
      }
      FishUpdated = true;
    } 
  }
}
