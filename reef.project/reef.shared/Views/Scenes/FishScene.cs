
using System.Collections.Generic;
using reef.shared.Config;
using reef.shared.Controllers;
using reef.shared.Views.Sprites;
using reef.shared.Views.UI;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace reef.shared.Views.Scenes {
  public class FishScene : Scene {
    public FishScene(GameHost game)
      : base(game) {
      // Add the UI components
      // Problem apps button
      var btnTexture = CurrentGame.GameTextures.Get("fish");
      var screen = GameHost.Resolution.ActualSize;
      var margin = 10;
      var appsBtn = new Clickable(btnTexture) {
        LayerDepth = Layers.UI,
        Position = new Vector2(margin, screen.Y - margin)
      };
      appsBtn.OnStoppedTouch += () => {
        Debug.WriteLine("Apps button Clicked");
      };
      SceneObjs.Add(appsBtn);

      // FishDex Button
      var dexBtn = new Clickable(btnTexture) {
        LayerDepth = Layers.UI,
        Position = new Vector2(screen.X - margin, screen.Y - margin)
      };
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
      var fishTexture = CurrentGame.GameTextures.Get("fish");
      for (var i = 0; i < fishCount; i++) {
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
