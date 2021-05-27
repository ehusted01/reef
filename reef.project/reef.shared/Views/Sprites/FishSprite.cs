﻿using System;
using reef.shared.Utils;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace reef.shared.Views.Sprites {
  public class FishSprite : Sprite {

    public FishSprite(Texture2D texture)
      : base(texture) {
      ScreenBounds = GameHost.Resolution.ScreenBounds;
      RandomPosition();
      RandomSwimRate();
      RandomSize();
    }

    /// <summary>
    /// The fish's swim rate for the screen
    /// </summary>
    private Vector2 swimRate = new Vector2(0);

    /// <summary>
    /// The current screen bounds
    /// </summary>
    private Rectangle ScreenBounds;

    /// <summary>
    /// Assigns a random swim rate
    /// </summary>
    private void RandomSwimRate() {
      const float max = 0.7f;
      swimRate.X = Rng.Next(0.5f, max);
      swimRate.Y = Rng.Next(0.5f, max);
      if (Rng.Bool()) {
        swimRate.X *= -1;
      }
      if (Rng.Bool()) {
        swimRate.Y *= -1;
      }
    }

    /// <summary>
    /// Assigns a random size to the fish
    /// </summary>
    private void RandomSize() {
      const float variation = 0.1f;
      var scale = 0.1f + Rng.Next(-variation, variation);
      Scale = new Vector2(scale);
    }

    /// <summary>
    /// Determine a random position for the fish to be in
    /// </summary>
    private void RandomPosition() {
      const int wiggle = 300;
      // Starting position: middle of screen
      Position = new Vector2(450, 600); //Resolution.ScreenCentre();

      // Some variation
      Position.X += Rng.Next(-wiggle, wiggle);
      Position.Y += Rng.Next(-wiggle, wiggle);
    }

    public override void Update(GameTime gameTime) {
      // We want the fish to move around
      Position += swimRate;

      if (Position.X > ScreenBounds.Width || Position.X < 0) {
        swimRate.X *= -1;  // Reverse
      }

      if (Position.Y > ScreenBounds.Height || Position.Y < 0) {
        swimRate.Y *= -1;  // Reverse
      }

      base.Update(gameTime);
    }
  }
}
