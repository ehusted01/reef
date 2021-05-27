using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using reef.shared.Models.ContentManagers;

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

    public void Load() {
      List<string> fishList = new List<string>() {
        "fish-blue-tang",
        "fish-bottlenose-dolphin",
        "fish-chambered-nautilus",
        "fish-giant-clam",
        "fish-great-barracuda",
        "fish-long-spine-porcupinefish",
        "fish-mahi-mahi",
        "fish-marlin",
        "fish-ocean-sunfish",
        "fish-orange-clownfish",
        "fish-red-lionfish",
        "fish-red-pencil-urchin",
        "fish-sea-bunny",
        "fish-sea-wasp",
        "fish-seahorse",
        "fish"
      };

      List<string> uiList = new List<string>() {
        "ui-add",
        "ui-box-generic",
        "ui-box-locked",
        "ui-box",
        "ui-btn-dex",
        "ui-btn-stats",
        "ui-remove"
      };

      Add(fishList);
      Add(uiList);
    }
  }
}
