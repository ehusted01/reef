using reef.shared.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using reef.shared.Controllers;
using reef.shared.Views.Scenes;

namespace reef.shared {
  /// <summary>
  /// What hosts the entire FishApp visual system
  /// </summary>
  public class GameHost : Game {

    public GameHost() {
      if (Curr != null) throw new System.Exception("Cannot have more than one gamehost");
      Curr = this;
      _graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
      IsMouseVisible = true;
    }

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public GameHost Curr;

    protected override void Initialize() {
      // TODO: Add your initialization logic here

      base.Initialize();
    }

    protected override void LoadContent() {
      _spriteBatch = new SpriteBatch(GraphicsDevice);

      // TODO: use this.Content to load your game content here

      // Add the game scenes to the SceneController
      SceneController.AddSceneHandler(new FishScene(this));
    }

    protected override void Update(GameTime gameTime) {
      if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        Exit();

      // TODO: Add your update logic here
      GameObjs.Update(gameTime); // Update all of the game objects

      base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
      GraphicsDevice.Clear(Color.CornflowerBlue);

      // TODO: Add your drawing code here

      base.Draw(gameTime);
    }
  }
}
