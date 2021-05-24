using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace reef.shared.Views.Sprites.Components {
  public abstract class SpriteComponent<T> where T : Sprite {
    protected SpriteComponent(T obj) {
      Obj = obj;
    }

    protected T Obj;
  }
}
