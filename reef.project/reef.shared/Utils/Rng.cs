using System;
namespace reef.shared.Utils {
  public static class Rng {
    /// <summary>
    /// Our random number generator
    /// </summary>
    private static readonly Random rand = new Random();

    public static int Next(int min, int max) {
      return rand.Next(min, max);
    }

    public static float Next(float min, float max) {
      return rand.Next((int) min * 100, (int) max * 100) / 100.0f;
    }
  }
}
