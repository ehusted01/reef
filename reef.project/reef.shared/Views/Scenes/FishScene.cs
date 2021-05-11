using reef.shared.Views.Sprites;
using Microsoft.Xna.Framework;

namespace reef.shared.Views.Scenes {
  public class FishScene : Scene {
    public FishScene(GameHost game)
      : base(game) {
      // Create our test scene obj
      /*var tstTexture = game.GameTextures.Data["test"];
      var tst = new Sprite(tstTexture) {
        Position = new Vector2(250, 500)
      };
      SceneObjs.Add(tst);*/

      //Borders still exist - remove in overall drawing class?
      var backTexture = game.GameTextures.Data["placeholder_background"];
      var back = new Sprite(backTexture)
      {
          Position = new Vector2(450, 600), //Change to reflect phone boundaries!
          Scale = 2.0f
      };
      SceneObjs.Add(back);

      var fishTexture = game.GameTextures.Data["placeholder_fish"];
      var fish = new FishSprite(fishTexture)
      {
          Position = new Vector2(250, 1000),
          Scale = 0.33f,
          SpriteEffect = Microsoft.Xna.Framework.Graphics.SpriteEffects.FlipHorizontally
      };
      SceneObjs.Add(fish);

      
    }
  }
}
