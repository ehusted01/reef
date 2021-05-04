using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using reef.shared.Config;
using reef.shared.Models;

namespace reef.shared.Views.Scenes {
  public class Scene {
    public Scene(GameHost game) {
      CurrentGame = game;
    }

    /// <summary>
    /// A reference to the current game
    /// </summary>
    public GameHost CurrentGame;

    /// <summary>
    /// A collection objects held by the scene
    /// </summary>
    public List<GameObj> SceneObjs = new List<GameObj>();

    /// <summary>
    /// Called when deactivating this Scene
    /// </summary>
    public virtual void Deactivate() {
    }

    /// <summary>
    /// Called when Activating this scene
    /// </summary>
    public virtual void Activate() {
    }

    /// <summary>
    /// Updates the entire scene
    /// </summary>
    public virtual void Update(GameTime gameTime) {
    }

    /// <summary>
    /// Draws the entire scene
    /// </summary>
    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
      // Draw the background
      CurrentGame.GraphicsDevice.Clear(AppConfig.BackgroundColour);

      //Start drawing the sprites
      spriteBatch.Begin(
        SpriteSortMode.BackToFront,
        BlendState.AlphaBlend,
        null,
        null,
        null,
        null,
        null);

      // Draw the collected sprites
      GameObjs.DrawSprites(gameTime, spriteBatch);

      // Finished drawing the sprites
      spriteBatch.End();
    }
  }
}
