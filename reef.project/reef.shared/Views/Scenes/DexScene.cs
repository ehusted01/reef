using System.Diagnostics;
using Microsoft.Xna.Framework;
using reef.shared.Controllers;
using reef.shared.Config;
using reef.shared.Views.UI;

namespace reef.shared.Views.Scenes {
  public class DexScene : Scene {
    public DexScene(GameHost game)
      : base(game) {
      var btnTexture = CurrentGame.GameTextures.Get("fish");
      var screen = GameHost.Resolution.ActualSize;
      var margin = 10;
      var backBtn = new Clickable(btnTexture) {
        LayerDepth = Layers.UI,
        Position = new Vector2(margin, screen.Y - margin)
      };
      backBtn.OnStoppedTouch += () => {
        Debug.WriteLine("Back button Clicked");
        SceneController.SetGameScene<FishScene>();
      };
      SceneObjs.Add(backBtn);

      SetupGrid();
    }

    /// <summary>
    /// Sets up the fish grid for the scen
    /// </summary>
    private void SetupGrid() {
      var total = 20; // Just say it's 20 for now
      // We need a basic box
      var boxTexture = CurrentGame.GameTextures.Get("fish");

      // We need to know the position
      var row = 1;
      var rowMax = 3;
      var xSlice = GameHost.Resolution.ActualSize.X / rowMax + 1;
      var yPos = 100;

      for(var i = 0; i < total; i++) {
        // Create the box
        var box = new GridBox(boxTexture) {
          Position = new Vector2(xSlice * row, yPos)
        };
        SceneObjs.Add(box);

        // Move on to the next in the row
        row++;

        // Have we reached the maximum row count
        if (row != rowMax) continue; // No, so continue
        row = 1; // Reset the row
        yPos += 100; // Add to Y. TODO: Fix this
      }
    }

    public override void Activate() {
      var collection = GameHost.FishController.GetAll();
      foreach(var fish in collection) {
        Debug.WriteLine(fish);
      }
      base.Activate();
    }
  }
}
