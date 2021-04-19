using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace reef.shared.Views.Scenes {
  public class FishScene {
    public FishScene(GameHost game) {
      CurrentGame = game;
    }

    /// <summary>
    /// A reference to the current game
    /// </summary>
    protected GameHost CurrentGame;
  }
}
