#region Using Statements

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

#endregion

namespace reef.shared.Controllers {
  public class TouchController {

    /// <summary>
    /// When true, the touches are currently active
    /// </summary>
    private bool active;

    /// <summary>
    ///   The collection of touches
    /// </summary>
    public static TouchCollection Touches;

    /// <summary>
    /// The action invoked when the touches have been stopped
    /// </summary>
    public Action TouchesStopped;

    /// <summary>
    /// Checks the touch panel for any state
    /// </summary>
    /// <param name="gameTime"></param>
    public void Update(GameTime gameTime) {
      Touches = TouchPanel.GetState();
      if (Touches.Count > 0) {
        active = true;
      } else {
        if (!active) return;
        active = false;
        TouchesStopped?.Invoke();
      }
    }
  }
}
