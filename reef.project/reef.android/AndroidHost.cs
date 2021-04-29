﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using reef.shared;

namespace reef.android {
  public class AndroidHost : GameHost {

    public AndroidHost() : base() {

    }

    protected override void Initialize() {
      base.Initialize();
      // TODO: Add your initialization logic here
    }

    protected override void LoadContent() {
      base.LoadContent();
      // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime) {
      if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
          Exit();

      // TODO: Add your update logic here

      base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
      GraphicsDevice.Clear(Color.CornflowerBlue);

      // TODO: Add your drawing code here

      base.Draw(gameTime);
    }
  }
}