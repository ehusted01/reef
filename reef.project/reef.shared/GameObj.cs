using System;
using Microsoft.Xna.Framework;

namespace reef.shared {
  /// <summary>
  /// An object that exists within the application
  /// </summary>
  public abstract class GameObj {
    protected GameObj() {
    }

    /// <summary>
    /// Every object is updatable by the game
    /// </summary>
    /// <param name="gameTime"></param>
    public abstract void Update(GameTime gameTime);
  }
}
