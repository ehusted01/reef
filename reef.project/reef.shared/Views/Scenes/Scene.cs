using System;
using System.Collections.Generic;

namespace reef.shared.Views.Scenes {
  public abstract class Scene {
    public Scene(GameHost game) {
      CurrentGame = game;
    }

    /// <summary>
    /// A reference to the current game
    /// </summary>
    public GameHost CurrentGame;

    /// <summary>
    /// A collection objects held by the scene
    /// </summary>
    public List<GameObj> SceneObjs;

    public abstract void Deactivate();
  }
}
