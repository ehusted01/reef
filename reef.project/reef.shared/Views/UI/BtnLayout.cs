using System;
using Microsoft.Xna.Framework;
using reef.shared.Views.Sprites;

namespace reef.shared.Views.UI {
  public enum BtnPos {
    BottomLeft,
    BottomRight
  }

  public class BtnLayout {

    public const int margin = 10;

    public static Vector2 GetPosition(BtnPos pos, Sprite sprite) {
      var screen = GameHost.Resolution.ActualSize;

      switch (pos) {
        case BtnPos.BottomLeft:
          return new Vector2(
            (sprite.SpriteTexture.Width * sprite.Scale.X / 2) + margin,
            screen.Y - (sprite.SpriteTexture.Height * sprite.Scale.Y / 2) - margin);
        case BtnPos.BottomRight:
          return new Vector2(
            screen.X - (sprite.SpriteTexture.Width * sprite.Scale.X / 2) - margin,
            screen.Y - (sprite.SpriteTexture.Height * sprite.Scale.Y / 2) - margin);
        default:
          throw new ArgumentOutOfRangeException();
      }       
    }
  }
}
