using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace reef.shared.Utils {
  public static class Resolution {

    private static GraphicsDeviceManager graphicsDevice;
    private static Matrix scaleMatrix;
    private static float aspectRatio = 0.0f;
    private static bool fullScreen = true;
    private static bool dirtyMatrix = true;
    private static Point virtualScreen = new Point(320, 480);

    public static Point Screen = new Point(320, 480);
    public static Rectangle ScreenSize;
    public static Vector3 ScalingFactor;
    public static bool ScalingNonzero;
    public static Rectangle ScreenBounds;

    private static float ScreenHeight {
      get {
        var scaleRatio = ScalingFactor.Y / ScalingFactor.X;
        var positionY = Math.Floor(virtualScreen.Y * scaleRatio);
        return (int)positionY;
      }
    }

    private static void ApplyResolutionSettings() {
      dirtyMatrix = true;
      graphicsDevice.PreferredBackBufferWidth = Screen.X;
      graphicsDevice.PreferredBackBufferHeight = Screen.Y;
      graphicsDevice.IsFullScreen = fullScreen;
      graphicsDevice.ApplyChanges();
      RecreateScaleMatrix();
    }

    private static void RecreateScaleMatrix() {
      dirtyMatrix = false;
      GetScalingFactor();
      var widthScaling = new Vector3(ScalingFactor.X, ScalingFactor.X, ScalingFactor.Z);
      ScreenSize = new Rectangle(0, 0, virtualScreen.X, (int)ScreenHeight);
      scaleMatrix = Matrix.CreateScale(widthScaling);
    }

    /// <summary>
    ///   Caluclate & set the Scaling Factor
    /// </summary>
    /// <returns></returns>
    private static Vector3 GetScalingFactor() {
      var widthScale = (float)Screen.X / virtualScreen.X;
      var heightScale = (float)Screen.Y / virtualScreen.Y;
      ScalingFactor = new Vector3(widthScale, heightScale, 1f);
      if (Math.Abs(widthScale) > 0.0f) {
        ScalingNonzero = true;
      }
      return ScalingFactor;
    }

    public static void Init(ref GraphicsDeviceManager device) {
      graphicsDevice = device;

      ScreenBounds = new Rectangle(
        0,
        0,
        GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width,
        GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height
      );

      // Set the Width & Height based on the device readings 
      //Screen.X = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
      //Screen.Y = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
      //dirtyMatrix = true;
      //fullScreen = true;
      //SetResolution(Screen.X, Screen.Y, fullScreen);
    }

    public static Matrix GetTransformationMatrix() {
      if (dirtyMatrix) RecreateScaleMatrix();
      return scaleMatrix;
    }

    /// <summary>
    ///   Set the actual device resolution
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="fullScreen"></param>
    public static void SetResolution(int width, int height, bool fullScreen) {
      Screen.X = width;
      Screen.Y = height;

      // Set the aspect ratio
      aspectRatio = (float)width / height;

      // Set the fullscreen property
      Resolution.fullScreen = fullScreen;

      // Apply the updated resolution settings
      ApplyResolutionSettings();
    }

    /// <summary>
    /// Gets the current screen centre
    /// </summary>
    /// <returns></returns>
    public static Vector2 ScreenCentre() {
      return new Vector2() {
        X = ScreenBounds.Width / 2,
        Y = ScreenBounds.Height / 2
      };
    }
  }
}
