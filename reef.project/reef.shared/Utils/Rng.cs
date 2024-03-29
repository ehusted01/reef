﻿using System;
using System.Collections.Generic;

namespace reef.shared.Utils {
  public static class Rng {
    /// <summary>
    /// Our random number generator
    /// </summary>
    private static readonly Random rand = new Random();

    public static bool Bool() {
      return rand.NextDouble() > 0.5;
    }

    /// <summary>
    /// Get a random element from a list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <returns></returns>
    public static T Next<T>(this List<T> list) {
      return list.Count <= 0 ? default : list[rand.Next(list.Count)];
    }

    public static int Next(int min, int max) {
      return rand.Next(min, max);
    }

    public static float Next(float max) {
      return rand.Next((int)max * 100) / 100.0f;
    }

    public static float Next(float min, float max) {
      float res = rand.Next((int)(min * 100), (int)(max * 100)) / 100.0f;
      return res;
    }
  }
}
