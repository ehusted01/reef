using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using reef.shared.Models.Device;

namespace reef.shared.Controllers {
  public class FishSpriteController {
    private Dictionary<string, string> associatedFile = new Dictionary<string, string>();

    /// <summary>
    /// Get the associated fish sprite
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public Texture2D Get(string key) {
      if (!associatedFile.ContainsKey(key)) throw new ArgumentOutOfRangeException();
      return GameHost.Curr.TextureController.Get(associatedFile[key]);
    }

    /// <summary>
    /// Load the fish data
    /// </summary>
    /// <param name="gameIO"></param>
    /// <param name="filename"></param>
    public void Load(GameIO gameIO, string filename) {

    }
  }
}
