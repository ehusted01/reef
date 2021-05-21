using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using reef.shared.Controllers;
using reef.shared.Models;
using reef.shared.Views.Sprites;

namespace reef.shared.View.UI {
  public class Clickable : Sprite {

    /// <summary>
    /// Make a clickable object
    /// </summary>
    public Clickable(Texture2D texture) 
      : base(texture) {
    }

    /// <summary>
    /// When true, the clickable is currently being touched
    /// </summary>
    private bool beingTouched;

    /// <summary>
    /// when true, this clickable has been selected
    /// </summary>
    private bool selected;

    /// <summary>
    /// When true, this clickable is active
    /// </summary>
    public bool Active = true;

    /// <summary>
    /// Action invoked on clickable touch
    /// </summary>
    public Action OnTouch;

    public Action OnStoppedTouch;

    private bool IsSpriteAtPoint(Vector2 pos) {
      // Is the position within the hitbox of the sprite?
      if (!Hitbox.Collision(pos)) return false;

      // Are there any objects above this object?
      return !GameHost.Curr.Objs.ObjsAtLocation(this, pos);
    }

    /// <summary>
    /// Reset the clickable
    /// </summary>
    private void Reset() {
      selected = false;
      beingTouched = false;
    }

    public override void Update(GameTime gameTime) {
      // We need to be aware that the user can click on this
      if (Active) {
        // Are there active touches?
        if (TouchController.Touches.Count > 0) {
          beingTouched = IsSpriteAtPoint(TouchController.Touches.Last().Position);

          if (beingTouched && !selected) {
            selected = true; // It's currently selected
            OnTouch?.Invoke(); // So invoke the first touch action
          }

          else if (!beingTouched && selected) {
            Reset(); // Reset it.
            OnStoppedTouch?.Invoke();
          }
        }
      }
      base.Update(gameTime);
    }
  }
}
