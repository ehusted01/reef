using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using reef.shared.Config;

namespace reef.shared.Utils {
  public class Resolution {

    public Resolution(ref GraphicsDeviceManager device) {
      graphicsDevice = device;

      // Set our virtual screen
      virtualScreen = new Point(AppConfig.ScreenSize[0], AppConfig.ScreenSize[1]);

      // Set the current resolution
      SetResolution(
        GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width,
        GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height,
        fullScreen
      );
    }

    private GraphicsDeviceManager graphicsDevice;
    private Point virtualScreen;
    private Matrix scaleMatrix;
    private bool dirtyMatrix = true;
    private static bool fullScreen = true;

    /// <summary>
    /// The actual screen size
    /// </summary>
    public Point ActualSize;

    /// <summary>
    /// The current screen bounds
    /// </summary>
    public Rectangle ScreenBounds;

    /// <summary>
    /// The current scaling factor of the app
    /// </summary>
    public Vector3 ScalingFactor;

    /// <summary>
    ///  Caluclate the Scaling Factor
    /// </summary>
    /// <returns></returns>
    private Vector3 CalcScalingFactor() {
      var widthScale = (float)ActualSize.X / virtualScreen.X;
      var heightScale = (float)ActualSize.Y / virtualScreen.Y;
      return new Vector3(widthScale, heightScale, 1f);
    }

    /// <summary>
    /// Calculate our current screen height
    /// </summary>
    /// <returns></returns>
    private int CalcScreenHeight() {
      // Get our screen height
      var scaleRatio = ScalingFactor.Y / ScalingFactor.X;
      var positionY = Math.Floor(virtualScreen.Y * scaleRatio);
      return (int)positionY;
    }

    /// <summary>
    /// Re-create the current scale matrix
    /// </summary>
    /// <returns></returns>
    private Matrix RecreateScaleMatrix() {
      ScalingFactor = CalcScalingFactor(); // calculate our scaling factor
      var screenHeight = CalcScreenHeight(); // calculate our screen height
      var widthScaling = new Vector3(
        ScalingFactor.X,
        ScalingFactor.X,
        ScalingFactor.Z
      );

      // Set our scale matrix
      scaleMatrix = Matrix.CreateScale(widthScaling);

      // Set our bounds
      ScreenBounds = new Rectangle(0, 0, virtualScreen.X, screenHeight);

      // And we're done
      dirtyMatrix = false;
      return scaleMatrix;
    }

    /// <summary>
    /// Get the current scale transformation matrix
    /// </summary>
    /// <returns>Scale Matrix</returns>
    public Matrix GetTransformationMatrix() {
      // Is the matrix dirty? No? Nothing to do
      if (!dirtyMatrix) return scaleMatrix;

      // Otherwise we have to re-create the scale matrix
      return RecreateScaleMatrix();
    }

    /// <summary>
    /// Set the actual device resolution
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="fullScreen"></param>
    public void SetResolution(int width, int height, bool fullScreen) {
      ActualSize.X = width;
      ActualSize.Y = height;

      // Set the fullscreen property
      Resolution.fullScreen = fullScreen;

      // Now apply the changes
      dirtyMatrix = true;
      graphicsDevice.PreferredBackBufferWidth = ActualSize.X;
      graphicsDevice.PreferredBackBufferHeight = ActualSize.Y;
      graphicsDevice.IsFullScreen = fullScreen;
      graphicsDevice.ApplyChanges();
      RecreateScaleMatrix();
    }

    /// <summary>
    /// Gets the current screen centre
    /// </summary>
    /// <returns></returns>
    public Vector2 GetScreenCentre() {
      return new Vector2() {
        X = ActualSize.X / 2,
        Y = ActualSize.Y / 2
      };
    }
  }
}
