﻿using reef.shared.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
    }

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public static GameHost Curr;
    public World World;
    public IDeviceActivity DeviceActivity;
    public InstalledApps InstalledApps;
    public GameTextures GameTextures;
    public GameIO GameIO;
    public FishManager fishManager;

    protected override void Initialize() {
      // TODO: Add your initialization logic here
      World = new World(); // Create the new world
      GameTextures = new GameTextures(Content); // Our game textures
      fishManager = new FishManager();
      base.Initialize();           
    }

    protected override void LoadContent() {
      _spriteBatch = new SpriteBatch(GraphicsDevice);

      // TODO: use this.Content to load your game content here
      GameTextures.Load(); // Load all of our textures

      if (GameIO == null) {
        throw new System.Exception("WHY");
      }
      fishManager.Load(GameIO);

      // Add the Game Scenes to the SceneController
      SceneController.AddSceneHandler(new FishScene(this));
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
