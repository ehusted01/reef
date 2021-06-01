using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using reef.shared.Config;

namespace reef.shared.Views.UI {
  class BtnFactory {
    public static Clickable GetBtn(string texture, BtnPos position) {
      var btnTexture = GameHost.GameTextures.Get(texture);
      var scale = new Vector2(0.5f);

      var btn = new Clickable(btnTexture) {
        LayerDepth = Layers.UI,
        Scale = scale
      };
      btn.Position = BtnLayout.GetPosition(position, btn);

      return btn;
    }
  }
}
