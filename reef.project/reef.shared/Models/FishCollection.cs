using System.Collections.Generic;
using reef.shared.Models.Fishes;
using reef.shared.Utils;

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
    /// The current list of our fish
    /// </summary>
    private List<Fish> collection = new List<Fish>();

    /// <summary>
    /// When flagged as true, our fish collection has been modified
    /// </summary>
    public bool Updated = false;

    public int Count() {
      return collection.Count;
    }

    /// <summary>
    /// Add a fish to this collection
    /// </summary>

    public void AddFish(Fish fish) {
      collection.Add(fish); // Add the fish to our collection
      Updated = true;
    }

    /// <summary>
    /// Remove a fish from this collection
    /// </summary>
    public void RemoveFish() {
      // Remove a fish at random from the list
      var randomFish = Rng.Next(collection);
      collection.Remove(randomFish);
      Updated = true;
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
