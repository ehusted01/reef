using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using reef.shared.Models.Device;
using reef.shared.Views.Sprites;

namespace reef.shared.Controllers {

  public class FishSpriteController {
    private Dictionary<string, FishSpriteData> data = new Dictionary<string, FishSpriteData>();

    public Texture2D GetTexture(string key) {
      if (!data.ContainsKey(key)) throw new ArgumentOutOfRangeException();
      return GameHost.TextureController.Get(data[key].Sprite);
    }

    /// <summary>
    /// Get the associated fish sprite
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public FishSprite Get(string key) {
      if (!data.ContainsKey(key)) throw new ArgumentOutOfRangeException();
      return new FishSprite(GameHost.TextureController.Get(data[key].Sprite), data[key].Size);
    }

    /// <summary>
    /// Load the fish data
    /// </summary>
    /// <param name="gameIO"></param>
    /// <param name="filename"></param>
    public void Load(GameIO gameIO, string filename) {
      gameIO.ReadLocalJsonFile(filename, (reader) => {
        var serializer = new JsonSerializer();
        using var json = new JsonTextReader(reader);
        var list = serializer.Deserialize<List<FishSpriteJson>>(json);
        foreach (var ele in list) {
          data.Add(ele.Fish.Key, ele.Fish);
          Debug.WriteLine(ele.Fish.Key);
        }
      });
    }

    private struct FishSpriteJson {
      [JsonProperty("fish")]
      public FishSpriteData Fish;
    }

    private struct FishSpriteData {
      [JsonProperty("key")]
      public string Key;

      [JsonProperty("sprite")]
      public string Sprite;

      [JsonProperty("size")]
      [JsonConverter(typeof(StringEnumConverter))]
      public FishSize Size;
    }
  }
}
