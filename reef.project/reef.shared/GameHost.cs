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
using reef.shared.Models.Fishes;

namespace reef.shared {
  /// <summary>
  /// What hosts the entire FishApp UI
  /// </summary>
  public class GameHost : Game {

    public GameHost() {
      if (Curr != null) throw new System.Exception("Cannot have more than one gamehost");
      Curr = this;
      graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
      IsMouseVisible = true;
    }

    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    public GameObjs Objs;
    public World World;
    public InstalledApps InstalledApps;
    public DeviceActivity DeviceActivity;
    public GameTextures GameTextures;
    public FishLibrary FishLibrary;
    public GameIO GameIO;

    // Our controllers
    public TextureController TextureController;
    public TouchController TouchController;
    public FishCollectionController FishCollectionController;
    public static FishController FishController;
    public static ObjController ObjController;

    public static Resolution Resolution;
    public static GameHost Curr;

    protected override void Initialize() {
      // Add your initialization logic here
      Resolution = new Resolution(ref graphics); // Setup the resolution
      Objs = new GameObjs(); // Our collection of game objects
      World = new World(DeviceActivity); // Create the new world
      GameTextures = new GameTextures(Content); // Our game textures
      FishLibrary = new FishLibrary(); // Our Fish Library

      // Set up our controllers
      ObjController = new ObjController(Objs); // The controller that updates our objects
      TextureController = new TextureController(GameTextures); // our game textures
      FishController = new FishController(FishLibrary); // The controller of our Fish Library
      TouchController = new TouchController(); // Our touch collection
      FishCollectionController = new FishCollectionController(World.DeviceActivity, World.Fishes); // The controller that updates the fish

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
      spriteBatch = new SpriteBatch(GraphicsDevice);

      // Load our content
      TextureController.Load(); // Load all of our textures
      FishController.Load(GameIO); // Load all of our fish

      // Add the Game Scenes to the SceneController
      SceneController.AddSceneHandler(new FishScene(this));
      SceneController.AddSceneHandler(new DexScene(this));

      // -- SETUP
      World.Setup(); // Setup our current world

      // TODO: Eventually check for a savefile here
      World.DeviceActivity.RecordUsageFrom(0); // Start tracking usage
      FishCollectionController.UpdateFish(); // Update what fish we have
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
      SceneController.CurrentSceneHandler.Draw(gameTime, spriteBatch);
      base.Draw(gameTime);
    }
  }
}
