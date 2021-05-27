using System;
using System.Collections.Generic;
using reef.shared.Models.ContentManagers;
using reef.shared.Models.Fish;

namespace reef.shared.Models {
  /// <summary>
  /// Contains all of the user information
  /// </summary>
  public class FishCollection {
    /// <summary>
    /// A stack containing the user's Fish.
    /// </summary>
    Stack<Fish.Fish> UserFish;
    /// <summary>
    /// The FishManager.
    /// </summary>
    FishManager FishManager;

    public FishCollection(/*FishManager fM*/) {
      //FishManager = fM;
      UserFish = new Stack<Fish.Fish>();
    }

    /// <summary>
    /// The default # of fish we start with
    /// </summary>
    public const int DefaultFishCount = 0;

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
      // UserFish.Push( some kind of fish );

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
      if (UserFish.Count != 0) {
        UserFish.Pop();
      }

      FishUpdated = true;
    } 
    /// <summary>
    /// Returns an array of the user's Fish
    /// </summary>
    /// <returns>an array of the user's Fish</returns>
    public Fish.Fish[] GetFish() {
      return UserFish.ToArray();
    }
  }
}
