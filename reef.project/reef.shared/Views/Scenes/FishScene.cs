
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
      var screen = GameHost.Resolution.ActualSize;
      var scale = new Vector2(3);

      var appsBtn = new Clickable(GameHost.GameTextures.Get("ui-btn-stats")) {
        LayerDepth = Layers.UI,
        Scale = scale
      };
      appsBtn.Position = BtnLayout.GetPosition(BtnPos.BottomLeft, appsBtn);
      appsBtn.OnStoppedTouch += () => {
        Debug.WriteLine("Apps button Clicked");
        SceneController.SetGameScene<AppsScene>();
      };
      SceneObjs.Add(appsBtn);

      // FishDex Button
      var dexBtn = new Clickable(GameHost.GameTextures.Get("ui-btn-dex")) {
        LayerDepth = Layers.UI,
        Scale = scale
      };
      dexBtn.Position = BtnLayout.GetPosition(BtnPos.BottomRight, dexBtn);
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
      int fishCount = CurrentGame.World.Fishes.Count();
      var fishTexture = GameHost.GameTextures.Get("fish-blue-tang");
      List<Fish> fishes = CurrentGame.World.Fishes.GetFish();
      foreach (Fish feesh in fishes) {
        try {
            String nickName = feesh.nickName;
            nickName = nickName.Replace(" ", "-");
            nickName = nickName.ToLower();
            nickName = "fish-" + nickName;
            fishTexture = GameHost.GameTextures.Get(nickName);
        } catch (Exception e) {
            fishTexture = GameHost.GameTextures.Get("fish-blue-tang");
        }
        var fishSprite = new FishSprite(fishTexture);
        fish.Add(fishSprite);
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
