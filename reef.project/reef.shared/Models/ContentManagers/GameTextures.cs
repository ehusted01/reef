using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace reef.shared.Models.ContentManagers {
  public class GameTextures {
    public GameTextures(ContentManager content) {
      this.content = content;
    }

    private ContentManager content;
    public Dictionary<string, Texture2D> Data = new Dictionary<string, Texture2D>();

    /// <summary>
    /// Load the game textures
    /// </summary>
    public void Load() {
      Data.Add("test", content.Load<Texture2D>("test"));
   }
  }
}
