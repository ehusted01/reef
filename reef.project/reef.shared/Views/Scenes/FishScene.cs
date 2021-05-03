using reef.shared.Views.Sprites;

namespace reef.shared.Views.Scenes {
  public class FishScene : Scene {
    public FishScene(GameHost game)
      : base(game) {
      // Create our test scene obj
      var tstTexture = game.GameTextures.Data["test"];
      var tst = new Sprite(tstTexture);
      SceneObjs.Add(tst);
    }
  }
}
