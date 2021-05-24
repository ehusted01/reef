using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using reef.shared.Utils;

namespace reef.shared.Views.Sprites.Components {
  public class Hitbox : SpriteComponent<Sprite> {
    public Hitbox(Sprite obj) 
      : base (obj) {
    }

    public float Scale = 1f;

    /// <summary>
    /// When TRUE, things can collide with the hitbox
    /// </summary>
    public bool Enabled = true;

    /// <summary>
    /// Get the bounds of the object
    /// </summary>
    private Rectangle GetBounds() {
      Vector2 spriteSize;
      
      // Nothing to do here
      if (Obj.SpriteTexture == null) return new Rectangle();

      // Is our source rectangle empty?
      if (Obj.SourceRect.IsEmpty) {
        // The size is that of the whole texture
        spriteSize = new Vector2(Obj.SpriteTexture.Width, Obj.SpriteTexture.Height);
      } else {
        // The size is that of the rectangle
        spriteSize = new Vector2(Obj.SourceRect.Width, Obj.SourceRect.Height);
      }

      // Build a rectangle whose position and size matches that of the sprite
      // (taking scaling into account for the size)
      var result = new Rectangle(
        (int)Obj.Position.X,
        (int)Obj.Position.Y,
        (int)(spriteSize.X * Obj.Scale.X * Scale),
        (int)(spriteSize.Y * Obj.Scale.Y * Scale));

      // Offset the sprite by the origin
      result.Offset(
        (int)(-Obj.Origin.X * Obj.Scale.X * Scale),
        (int)(-Obj.Origin.Y * Obj.Scale.Y * Scale));

      // Return the finished rectangle
      return result;
    }

    /// <summary>
    /// Determine whether the specified point is contained within the sprite
    /// </summary>
    /// <param name="point"></param>
    /// <returns>True if the point is within the shape, false if not</returns>
    public bool Collision(Vector2 point) {
      if (!Enabled) return false;
      var (x, y) = point;

      // Adjust for resolution
      //return GetBounds().Contains(
      //  (int) (point.X / Resolution.ScalingFactor.X), 
      //  (int) (point.Y / Resolution.ScalingFactor.X));
      return GetBounds().Contains((int)x, (int)y);
    }
  }

}
