using System;
using reef.shared.Utils;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace reef.shared.Views.Sprites {
  public class FishSprite : Sprite {

    public FishSprite(Texture2D texture)
      : base(texture) {
      RandomPosition();
      RandomSwimRate();
      RandomSize();
    }

    /// <summary>
    /// The fish's swim rate for the screen
    /// </summary>
    private Vector2 swimRate = new Vector2(0);

    /// <summary>
    /// Assigns a random swim rate
    /// </summary>
    private void RandomSwimRate() {
      swimRate.X = 0.05f + Rng.Next(-0.1f, 0.1f);
      swimRate.Y = 0.05f + Rng.Next(-0.1f, 0.1f);
    }

    /// <summary>
    /// Assigns a random size to the fish
    /// </summary>
    private void RandomSize() {
      Scale = 0.5f + Rng.Next(-0.1f, 0.1f);
    }

    /// <summary>
    /// Determine a random position for the fish to be in
    /// </summary>
    private void RandomPosition() {
      const int wiggle = 300;
      // Starting position: middle of screen
      Position = new Vector2(500, 600);

      // Some variation
      Position.X += Rng.Next(-wiggle, wiggle);
      Position.Y += Rng.Next(-wiggle, wiggle);
    }

    public override void Update(GameTime gameTime) {
      // We want the fish to move around
      Position += swimRate;
      base.Update(gameTime);
    }
  }
}
