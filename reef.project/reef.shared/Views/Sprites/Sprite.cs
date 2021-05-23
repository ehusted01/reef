using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using reef.shared.Utils;
using reef.shared.Config;
using reef.shared.Views.Sprites.Components;

namespace reef.shared.Views.Sprites {
  /// <summary>
  /// A sprite is a drawable object that renders a 2D sprite texture on screen
  /// </summary>
  public class Sprite : GameObj {
    public Sprite() :
      base() {
      Hitbox = new Hitbox(this); // Add a hitbox component
    }

    public Sprite(Texture2D texture) :
      this() {
      SpriteTexture = texture;
      Origin = texture.GetOrigin();
    }

    /// <summary>
    /// The current calculated colour, based on Colour * Opacity
    /// Done on update
    /// </summary>
    private Color currentColour;

    /// <summary>
    /// The sprite texture for the sprite
    /// </summary>
    public Texture2D SpriteTexture;

    /// <summary>
    /// An optional source rectangle to read from the sprite texture
    /// </summary>
    public Rectangle SourceRect;

    /// <summary>
    /// The position of the object
    /// </summary>
    public Vector2 Position = new Vector2(0, 0);

    /// <summary>
    /// The colour of the object
    /// </summary>
    public Color SpriteColour = Color.White;

    /// <summary>
    /// The opacity of the object
    /// </summary>
    public float Opacity = 1.0f;

    /// <summary>
    /// The angle of the object
    /// </summary>
    public float Angle = 0.0f;

    /// <summary>
    /// The origin of the object
    /// </summary>
    public Vector2 Origin;

    /// <summary>
    /// The scale of the object
    /// </summary>
    public Vector2 Scale = new Vector2(1);

    /// <summary>
    /// The active sprite effects of the object
    /// </summary>
    public SpriteEffects SpriteEffect = SpriteEffects.None;

    /// <summary>
    /// The layerdepth of the object
    /// </summary>
    public float LayerDepth = Layers.Default;

    /// <summary>
    /// The hitbox of the object
    /// </summary>
    public Hitbox Hitbox;

    public override void Update(GameTime gameTime) {
      currentColour = SpriteColour * Opacity; // Update the current colour
    }

    /// <summary>
    /// Every sprite is drawable
    /// </summary>
    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
      // Do we have a texture? If not then there is nothing to draw...
      if (SpriteTexture == null) return;

      // Has a source rectangle been set?
      if (SourceRect.IsEmpty) { // No, so draw the entire sprite texture
        spriteBatch.Draw(
          SpriteTexture,
          Position,
          null,
          currentColour,
          Angle,
          Origin,
          Scale,
          SpriteEffect,
          LayerDepth);
      }
      else { // Yes, so just draw the specified SourceRect
        spriteBatch.Draw(
          SpriteTexture,
          Position,
          SourceRect,
          currentColour,
          Angle,
          Origin,
          Scale,
          SpriteEffect,
          LayerDepth);
      }
    }
  }
}
