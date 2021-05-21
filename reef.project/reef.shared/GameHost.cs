using reef.shared.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using reef.shared.Utils;
using reef.shared.Controllers;
using reef.shared.Views.Scenes;
using reef.shared.Models.Device;
using reef.shared.Models.ContentManagers;
using reef.shared.Config;

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
    public GameObjs Objs;
    public static GameHost Curr;
    public World World;
    public InstalledApps InstalledApps;
    public DeviceActivity DeviceActivity;
    public GameTextures GameTextures;

    public TouchController TouchController;
    public FishController FishController;
    public ObjController ObjController;

    protected override void Initialize() {
      // TODO: Add your initialization logic here
      Objs = new GameObjs(); // Our collection of game objects
      World = new World(DeviceActivity); // Create the new world
      GameTextures = new GameTextures(Content); // Our game textures
      TouchController = new TouchController(); // Our touch collection
      ObjController = new ObjController(Objs); // The controller that updates our objects
      FishController = new FishController(World.DeviceActivity, World.Fishes); // The controller that updates the fish

      // Track all installed apps as problem apps
      foreach (AppInfo app in InstalledApps.Get()) {
        // Sanity check: don't track our own package
        if (app.GetPackage().Equals(AppConfig.PackageName)) {
          continue;
        }
        World.DeviceActivity.Track(app);
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

      // TODO: Eventually check for a savefile here
      World.DeviceActivity.RecordUsageFrom(0); // Start tracking usage
      FishController.UpdateFish(); // Update what fish we have
      SceneController.SetGameScene<FishScene>(); // Set our starting scene
    }

    protected override void Update(GameTime gameTime) {
      if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        Exit();

      TouchController.Update(gameTime); // Update our touches
      Objs.Update(gameTime); // Update all of the game objects
      SceneController.CurrentSceneHandler.Update(gameTime); // Update the actual scene

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
