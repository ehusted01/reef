
using System.Collections.Generic;
using reef.shared.Controllers;
using reef.shared.Views.Sprites;
using Microsoft.Xna.Framework;

namespace reef.shared.Views.Scenes {
  public class FishScene : Scene {
    public FishScene(GameHost game)
      : base(game) {
      
    }

    private List<Sprite> fish = new List<Sprite>();

    /// <summary>
    /// Populate our current scene with fish
    /// </summary>
    private void PopulateFish() {
      // Remove the current fish from the game objects
      CurrentGame.ObjController.RemoveRange(fish);

      // Clear the current fish section
      fish.Clear();
      int fishCount = CurrentGame.World.Fishes.FishCount;
      var fishTexture = CurrentGame.GameTextures.Get("fish");
      for (var i = 0; i < fishCount; i++) {
        var fishSprite = new FishSprite(fishTexture);
        fish.Add(fishSprite);
      }

      // Add fish to the GameObjs
      CurrentGame.ObjController.Add(fish);
      CurrentGame.World.Fishes.FishUpdated = false;
    }

    public override void Update(GameTime gameTime) {
      if (CurrentGame.World.Fishes.FishUpdated) {
        PopulateFish();
      }
      base.Update(gameTime);
    }

    public override void Activate() {
      PopulateFish();
      base.Activate();
    }
  }
}
