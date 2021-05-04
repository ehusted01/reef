using reef.shared.Views.Sprites;
using Microsoft.Xna.Framework;

namespace reef.shared.Views.Scenes {
  public class FishScene : Scene {
    public FishScene(GameHost game)
      : base(game) {
      // Create our test scene obj
      var tstTexture = game.GameTextures.Data["test"];
      var tst = new Sprite(tstTexture) {
        Position = new Vector2(250, 500)
      };
      SceneObjs.Add(tst);
    }
  }
}
