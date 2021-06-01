
using System.Collections.Generic;
using reef.shared.Config;
using reef.shared.Controllers;
using reef.shared.Views.Sprites;
using reef.shared.Views.UI;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using reef.shared.Models.Fishes;
using System;

namespace reef.shared.Views.Scenes {
  public class FishScene : Scene {
    public FishScene(GameHost game)
      : base(game) {
      // Add the UI components
      // Problem apps button

      var appsBtn = BtnFactory.GetBtn("ui-btn-stats-big", BtnPos.BottomLeft);
      appsBtn.OnStoppedTouch += () => {
        Debug.WriteLine("Apps button Clicked");
        SceneController.SetGameScene<AppsScene>();
      };
      SceneObjs.Add(appsBtn);

      // FishDex Button
      var dexBtn = BtnFactory.GetBtn("ui-btn-dex-big", BtnPos.BottomRight);
      dexBtn.OnStoppedTouch += () => {
        Debug.WriteLine("Dex button clicked");
        SceneController.SetGameScene<DexScene>();
      };
      SceneObjs.Add(dexBtn);
    }

    /// <summary>
    /// The collection of the fish
    /// </summary>
    private List<Sprite> fish = new List<Sprite>();

    /// <summary>
    /// Populate our current scene with fish
    /// </summary>
    private void PopulateFish() {
      // Remove the current fish from the game objects
      GameHost.ObjController.RemoveRange(fish);

      // Clear the current fish section
      fish.Clear();
      var fishes = GameHost.FishCollectionController.GetAll();
      foreach (var feesh in fishes) {
        fish.Add(GameHost.FishSpriteController.Get(feesh.speciesName));
      }

      // Add fish to the GameObjs
      GameHost.ObjController.Add(fish);
      CurrentGame.World.Fishes.Updated = false;
    }

    public override void Update(GameTime gameTime) {
      if (CurrentGame.World.Fishes.Updated) {
        PopulateFish();
      }
      base.Update(gameTime);
    }

    public override void Activate() {
      PopulateFish();
    }
  }
}
