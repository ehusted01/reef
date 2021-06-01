using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using reef.shared.Config;

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
      if (!Data.ContainsKey(key))throw new Exception("Texture not in dictionary: "+key);
      return Data[key];
    }

    /// <summary>
    /// Load a texture
    /// </summary>
    /// <param name="key"></param>
    public void Load(string key) {
      if (Data.ContainsKey(key)) throw new Exception("Duplicate key");
      try {
        Data.Add(key, content.Load<Texture2D>(key));
      }
      catch (Exception e) {
        throw new Exception("Can't find texture: "+key);
      }
    }

    /// <summary>
    /// Load textures from a list
    /// </summary>
    /// <param name="lst"></param>
    public void Load(List<string> lst) {
      foreach(var key in lst) {
        try {
          Data.Add(key, content.Load<Texture2D>(key));
        }
        catch (Exception e) {
          throw new Exception("Can't find texture: "+key);
        }
      }
    }
  }
}
