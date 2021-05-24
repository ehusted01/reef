using System;
using Microsoft.Xna.Framework.Graphics;
using reef.shared.Views.Sprites;

namespace reef.shared.Views.UI {
  public class GridBox : Sprite {
    /// <summary>
    /// A gridbox should contain a representational image of the fish
    /// </summary>
    /// <param name="texture"></param>
    public GridBox(Texture2D texture)
      : base(texture) {
    }

  }
}
