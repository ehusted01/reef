using System;
using Microsoft.Xna.Framework.Graphics;
using reef.shared.Views.Sprites;
using reef.shared.Models.Fishes;
using reef.shared.Controllers;
using Microsoft.Xna.Framework;

namespace reef.shared.Views.UI {
  public class GridBox : Sprite {
    /// <summary>
    /// A gridbox should contain a representational image of the fish
    /// </summary>
    /// <param name="texture"></param>
    public GridBox(Texture2D texture, Fish fish, bool unlocked)
      : base(texture) {
      if (unlocked) {
        SpriteColour = Color.Aquamarine;
      } else {
        SpriteColour = Color.Gray;
      }

      // Add the fish icon
      var fishIcon = GameHost.Curr.TextureController.Get("fish-blue-tang");
      icon = new Sprite(fishIcon) {
        Position = Position,
        LayerDepth = LayerDepth + 0.01f, // Sitting above the box
        Scale = new Vector2(0.1f)
      };
    }

    private Sprite icon;

    public override void Update(GameTime gameTime) {
      icon.Position = Position;
      icon.Update(gameTime);
      base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
      icon.Draw(gameTime, spriteBatch);
      base.Draw(gameTime, spriteBatch);
    }

  }
}
