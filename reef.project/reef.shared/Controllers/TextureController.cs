using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using reef.shared.Models.ContentManagers;
using reef.shared.Models.Device;

namespace reef.shared.Controllers {
  public class TextureController {
    public TextureController(GameTextures textures) {
      collection = textures;
    }

    private GameTextures collection;

    /// <summary>
    /// Add to the collection
    /// </summary>
    /// <param name="key"></param>
    public void Add(string key) {
       collection.Load(key);
    }

    /// <summary>
    /// Add to the collection from a list
    /// </summary>
    /// <param name="lst"></param>
    public void Add(List<string> lst) {
      collection.Load(lst);
    }

    /// <summary>
    /// Returns a texure with a specified key
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public Texture2D Get(string key) {
      return collection.Get(key);
    }

    public void Load(GameIO gameIO, string filename) {
      gameIO.ReadLocalJsonFile(filename, (reader) => {
        var serializer = new JsonSerializer();
        using var json = new JsonTextReader(reader);
        var list = serializer.Deserialize<List<string>>(json);
        Add(list);
      });
    }
  }
}
