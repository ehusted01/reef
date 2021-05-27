using System;
using Microsoft.Xna.Framework;

namespace reef.shared.Config {
  public struct AppConfig {
    /// <summary>
    /// Our package name
    /// </summary>
    public static string PackageName = "reef.android.reef.android";

    /// <summary>
    /// The default Background colour
    /// </summary>
    public static Color BackgroundColour = Color.AliceBlue;

    /// <summary>
    /// The default screen size of the app, stored as X, Y
    /// </summary>
    public static int[] ScreenSize = new int[2] { 1080, 1920 };


    /// <summary>
    /// Our json containing all of our fish
    /// </summary>
    public const string FishFile = "fish.json";
  }
}
