using reef.shared.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using reef.shared.Utils;
using reef.shared.Controllers;
using reef.shared.Views.Scenes;
using reef.shared.Models.Device;
using reef.shared.Models.ContentManagers;

namespace reef.shared {
  /// <summary>
  /// What hosts the entire FishApp UI
  /// </summary>
  public class GameHost : Game {

    public GameHost() {
      if (Curr != null) throw new System.Exception("Cannot have more than one gamehost");
      Curr = this;
      _graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
      IsMouseVisible = true;

      // Setup the
      Resolution.Init(ref _graphics);
    }

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public GameHost Curr;
    public World World;
    public IDeviceActivity DeviceActivity;
    public InstalledApps InstalledApps;
    public GameTextures GameTextures;
    public FishController FishController;

    protected override void Initialize() {
      // TODO: Add your initialization logic here
      World = new World(); // Create the new world
      GameTextures = new GameTextures(Content); // Our game textures
      FishController = new FishController(DeviceActivity, User); // The controller that updates the fish
      foreach (AppInfo app in InstalledApps.Get()) { // Track all installed apps as problem apps
          DeviceActivity.Track(app);
      }
      base.Initialize();
    }

    protected override void LoadContent() {
      _spriteBatch = new SpriteBatch(GraphicsDevice);

      // Load all of our textures
      GameTextures.Load();

      // Add the Game Scenes to the SceneController
      SceneController.AddSceneHandler(new FishScene(this));

      // -- SETUP
      World.Setup(); // Setup our current world
      SceneController.SetGameScene<FishScene>(); // Set our starting scene
    }

    protected override void Update(GameTime gameTime) {
      if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        Exit();

      // TODO: Add your update logic here
      GameObjs.Update(gameTime); // Update all of the game objects

      base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
      // TODO: Add your drawing code here
      // Draw the current scene
      SceneController.CurrentSceneHandler.Draw(gameTime, _spriteBatch);
      base.Draw(gameTime);
    }
  }
}
