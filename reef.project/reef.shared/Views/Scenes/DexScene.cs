using System.Diagnostics;
using Microsoft.Xna.Framework;
using reef.shared.Controllers;
using reef.shared.Config;
using reef.shared.Views.UI;

namespace reef.shared.Views.Scenes {
  public class DexScene : Scene {
    public DexScene(GameHost game)
      : base(game) {
      var backBtn = BtnFactory.GetBtn("ui-btn-stats-big", BtnPos.BottomLeft);
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
      // We need a basic box
      var boxTexture = GameHost.GameTextures.Get("ui-box-generic");

      // We need to know the position
      var row = 1;
      var xSlice = GameHost.Resolution.ActualSize.X / 4;
      var yPos = 300;
      var boxScale = new Vector2(1);

      // Get all of the fish
      var feeesh = GameHost.FishController.GetAll();
      var earned = GameHost.FishCollectionController.GetAll();
      bool unlocked;
      foreach(var fish in feeesh) {
        // Create the box
        unlocked = GameHost.Curr.World.Fishes.HasFish(fish);
        var box = new GridBox(boxTexture, fish, false) {
          Position = new Vector2(xSlice * row, yPos),
          Scale = boxScale,
          LayerDepth = Layers.Default
        };
        SceneObjs.Add(box);

        // Move on to the next in the row
        row += 2;

        // Have we reached the maximum row count
        if (row > 3) {
          row = 1; // Reset the row
          yPos += (boxTexture.Height * (int)boxScale.Y) + 50; // Add to Y. TODO: Fix this
        }
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
