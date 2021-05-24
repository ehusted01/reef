using reef.shared.Models;
using System.Collections.Generic;

namespace reef.shared.Controllers {
  /// <summary>
  /// Adds / remove objects from the object model
  /// </summary>
  public class ObjController {

    public ObjController(GameObjs objs) {
      gameObjs = objs;
    }

    private GameObjs gameObjs;

    public void Add<T>(T obj) where T : GameObj {
      gameObjs.Add(obj);
    }

    public void Add<T>(List<T> objs) where T : GameObj {
      gameObjs.Add(objs);
    }

    public void Remove<T>(T obj) where T : GameObj {
      gameObjs.Remove(obj);
    }

    public void RemoveRange<T>(List<T> objs) where T : GameObj {
      foreach (T obj in objs) {
        gameObjs.Remove(obj);
      }
    }

    public void Clear() {
      gameObjs.Objs.Clear();
    }
    
  }
}
