
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

    public override void Activate() {
      // Get and deploy fish onto the scene
      fish.Clear();
      int fishCount = CurrentGame.World.User.FishCount;
      var fishTexture = CurrentGame.GameTextures.Get("fish");
      for (var i = 0; i < fishCount; i++) {
        var fishSprite = new FishSprite(fishTexture);
        fish.Add(fishSprite);
      }

      // Add fish to the GameObjs
      ObjController.AddRange(fish);
      base.Activate();
    }
  }
}
