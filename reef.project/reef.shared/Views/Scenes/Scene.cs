using System;
namespace reef.shared.Views.Scenes {
  public class Scene {
    public Scene(GameHost game) {
      CurrentGame = game;
    }

    public GameHost CurrentGame;
  }
}
