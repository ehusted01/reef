
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace reef.shared.Utils {
  public enum OriginLoc {
    Middle,
    TopLeft,
    TopMiddle
  }
  public static class TextureHelper {
    public static Vector2 GetOrigin(this Texture2D texture, OriginLoc loc = OriginLoc.Middle) {
      switch (loc) {
        case OriginLoc.Middle:
          return new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
        case OriginLoc.TopLeft:
          return new Vector2(0, 0);
        case OriginLoc.TopMiddle:
          return new Vector2(texture.Width * 0.5f, 0);
        default:
          throw new ArgumentOutOfRangeException(nameof(loc), loc, null);
      }
    }
  }
}
