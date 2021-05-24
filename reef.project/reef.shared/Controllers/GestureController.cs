using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

namespace reef.shared.Controllers {
  public class GestureController {

    private bool gestureActive;

    public Action Finished;
    public GestureActions Tap = new GestureActions();
    public GestureActions Flick = new GestureActions();
    public GestureActions VerticalDrag = new GestureActions();
    public GestureActions FreeDrag = new GestureActions();

    /// <summary>
    /// Enable a specific gesture type(s) for use
    /// by the touch controller
    /// </summary>
    /// <param name="type"></param>
    public static void EnableGesture(GestureType type) {
      TouchPanel.EnabledGestures = type;
    }

    /// <summary>
    /// Disable the gestures
    /// </summary>
    public static void DisableGestures() {
      TouchPanel.EnabledGestures = GestureType.None;
    }

    public void Update(GameTime gameTime) {
      while (TouchPanel.IsGestureAvailable) {
        var gs = TouchPanel.ReadGesture();
        switch (gs.GestureType) {
          case GestureType.Tap:
            gestureActive = true;
            Tap.Action?.Invoke(gs);
            break;
          case GestureType.VerticalDrag:
            gestureActive = true;
            VerticalDrag.Action?.Invoke(gs);
            break;
          case GestureType.FreeDrag:
            gestureActive = true;
            FreeDrag.Action?.Invoke(gs);
            break;
          case GestureType.Flick:
            gestureActive = true;
            Flick.Action?.Invoke(gs);
            break;
          case GestureType.None:
            break;
          case GestureType.DragComplete:
            break;
          case GestureType.Hold:
            break;
          case GestureType.HorizontalDrag:
            break;
          case GestureType.Pinch:
            break;
          case GestureType.PinchComplete:
            break;
          case GestureType.DoubleTap:
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
      }

      if (!gestureActive) return;
      if (TouchController.Touches.Count > 0) return;
      gestureActive = false;
      Finished?.Invoke();
    }
    
    /// <summary>
    /// A container for touch callbacks
    /// </summary>
    public class GestureActions {
      private List<Action<GestureSample>> delegates = new List<Action<GestureSample>>();
      public Action<GestureSample> Action { get; private set; }
      public void RegisterCb(Action<GestureSample> cb) {
        Action += cb;
        delegates.Add(cb);
      }
      public void Clear() {
        foreach (var d in delegates) {
          Action -= d;
        }
      }
    }
  }
}
