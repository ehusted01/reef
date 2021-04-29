#region Using statements

using System;

#endregion

namespace reef.shared.Models {
  /// <summary>
  /// The world where everything "exists" within the application
  /// Follows the singleton pattern.
  /// </summary>
  public class World {
    public World() {
      if (Curr != null) throw new Exception("Can't have more than one world");
      Curr = this;
    }

    /// <summary>
    /// Setup the current world
    /// </summary>
    public void Setup() {
    }


    public static World Curr;
  }
}
