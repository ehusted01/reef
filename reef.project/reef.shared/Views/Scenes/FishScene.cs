
using System.Collections.Generic;
using reef.shared.Config;
using reef.shared.Controllers;
using reef.shared.Views.Sprites;
using reef.shared.Views.UI;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using reef.shared.Models.Fishes;
using System;
using System.Linq;
using reef.shared.Utils;

namespace reef.shared.Views.Scenes {
  public class FishScene : Scene {
    public FishScene(GameHost game)
      : base(game) {
      // Add the background
      var background = new Sprite(GameHost.TextureController.Get("background")) {
        LayerDepth = 0,
        Scale = new Vector2(2),
      };
      background.Origin = background.SpriteTexture.GetOrigin(OriginLoc.TopMiddle);
      SceneObjs.Add(background);

      // Add the UI components
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
    /// The collection of the fish sprites
    /// </summary>
    private List<Sprite> fishSprites = new List<Sprite>();
    private Dictionary<Fish, Queue<Sprite>> fish = new Dictionary<Fish, Queue<Sprite>>();

    /// <summary>
    /// Populate our current scene with fish
    /// </summary>
    private void PopulateFish() {
      // Remove the current fish from the game objects
      GameHost.ObjController.RemoveRange(fishSprites);
      fishSprites.Clear(); // Clear the list for use


      // Get all of our fish from our collection
      var fishes = GameHost.FishCollectionController.GetAll();
      var tmp = new Dictionary<Fish, Queue<Sprite>>();
      foreach (var feesh in fishes) {
        Sprite sprite;
        if (fish.ContainsKey(feesh) && fish[feesh].Any()) {
          sprite = fish[feesh].Dequeue();
        } else {
          sprite = GameHost.FishSpriteController.Get(feesh.speciesName);
        }

        if (!tmp.ContainsKey(feesh)) {
          tmp.Add(feesh, new Queue<Sprite>());
        }
        fishSprites.Add(sprite);
        tmp[feesh].Enqueue(sprite);
      }
      
      // Update our collection
      fish = tmp;

      // Add fish to the GameObjs
      GameHost.ObjController.Add(fishSprites);

      // Reset the flag
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
