using reef.shared.Models;
using System.Collections.Generic;

namespace reef.shared.Controllers {
  /// <summary>
  /// Adds / remove objects from the object model
  /// </summary>
  public static class ObjController {

    public static void Add<T>(T obj) where T : GameObj {
      GameObjs.UpdateFlag = true;
      GameObjs.Objs.Add(obj);
    }

    public static void AddRange<T>(List<T> objList) where T : GameObj {
      GameObjs.UpdateFlag = true;
      GameObjs.Objs.AddRange(objList);
    }

    public static void Remove<T>(T obj) where T : GameObj {
      GameObjs.UpdateFlag = true;
      GameObjs.Objs.Remove(obj);
    }

    public static void Clear() {
      GameObjs.UpdateFlag = true;
      GameObjs.Objs.Clear();
    }
    
  }
}
