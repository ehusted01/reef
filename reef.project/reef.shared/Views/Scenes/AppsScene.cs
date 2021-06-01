using System.Diagnostics;
using Microsoft.Xna.Framework;
using reef.shared.Controllers;
using reef.shared.Config;
using reef.shared.Views.UI;

namespace reef.shared.Views.Scenes {
  public class AppsScene : Scene {
    public AppsScene(GameHost game)
      : base(game) {
      var backBtn = BtnFactory.GetBtn("ui-btn-stats-big", BtnPos.BottomLeft);
      backBtn.OnStoppedTouch += () => {
        Debug.WriteLine("Back button Clicked");
        SceneController.SetGameScene<FishScene>();
      };
      SceneObjs.Add(backBtn);
    }
  }
}
