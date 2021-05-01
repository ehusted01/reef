﻿#region Using statements

using System;
using System.Collections.Generic;

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

    /// <summary>
    /// Saves the current state of the world in a savefile,
    /// And then writes that to local storage
    /// </summary>
    public void Save() {
      var someRandomList = new List<string>();
      var state = new SaveFile() {
        ExampleField = someRandomList
      };

      // ANd then we write that file to JSON
    }
  }
}
