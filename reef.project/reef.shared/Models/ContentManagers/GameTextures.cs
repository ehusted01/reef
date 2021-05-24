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
    /// Get a specfic texture from the stored textures
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public Texture2D Get(string key) {
      if (!Data.ContainsKey(key)) throw new Exception("Texture not in dictionary");
      return Data[key];
    }

    /// <summary>
    /// Load the game textures
    /// </summary>
    public void Load() {
      Data.Add("test", content.Load<Texture2D>("test"));
      Data.Add("fish", content.Load<Texture2D>("fish"));
    }
  }
}
