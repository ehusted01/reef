using System.Diagnostics;
using Microsoft.Xna.Framework;
using reef.shared.Controllers;
using reef.shared.Config;
using reef.shared.Views.UI;

namespace reef.shared.Views.Scenes {
  public class AppsScene : Scene {
    public AppsScene(GameHost game)
      : base(game) {
      var btnTexture = GameHost.GameTextures.Get("ui-box-generic");
      var scale = new Vector2(3);

      var backBtn = new Clickable(btnTexture) {
        LayerDepth = Layers.UI,
        Scale = scale
      };
      // Set the position
      backBtn.Position = BtnLayout.GetPosition(BtnPos.BottomLeft, backBtn);

      // Setup the callbacks
      backBtn.OnStoppedTouch += () => {
        Debug.WriteLine("Back button Clicked");
        SceneController.SetGameScene<FishScene>();
      };
      SceneObjs.Add(backBtn);
    }
  }
}
