
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace reef.shared.Utils {
  public static class TextureHelper {
    public static Vector2 GetOrigin(this Texture2D texture) {
      return new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
    }
  }
}
