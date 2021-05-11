using System;
namespace reef.shared.Models {
  /// <summary>
  /// Contains all of the user information
  /// </summary>
  public class User {
    public User() {
    }

    public int FishCount { get; private set; } = 0;

    /// <summary>
    /// Determine the reward for the activity
    /// </summary>
    private void DetermineReward() {
      FishCount = 3; /// For now, just set to 3
    }

    /// <summary>
    /// checks the current activity, compares it to previous activity
    /// </summary>
    public void CheckActivity() {
      DetermineReward();
    }

  }
}
