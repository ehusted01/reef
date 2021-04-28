#region Using Statments

using System.Collections.Generic;
using reef.shared.Views.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#endregion

namespace reef.shared.Models {
  /// <summary>
  /// A stored collection of our current game objects,
  /// responsible for updating & removing them.
  /// </summary>
  public static class GameObjs {
    /// <summary>
    /// A collection of all the game objects
    /// </summary>
    private static GameObj[] objArray = new GameObj[0];

    /// <summary>
    /// A list of active game objects.
    /// </summary>
    private static List<GameObj> objs = new List<GameObj>();

    /// <summary>
    /// Set to true when the obj list has been changed.
    /// </summary>
    private static bool updateFlag;

    /// <summary>
    /// How much to update the array allocation by
    /// </summary>
    private const float AddAlloc = 1.2f;

    /// <summary>
    /// Updates the entire array witht he game objects
    /// </summary>
    private static void UpdateArray() {
      // First build our array of objects.
      // We will iterate across this rather than across the actual GameObjects
      // collection so that the collection can be modified by the game objects' code.
      // First of all, do we have an array?
      if (objArray == null) {
        // No, so allocate it.
        // Allocate 20% more objects than we currently have, or 20 objects, whichever is more
        objArray = new GameObj[(int)MathHelper.Max(20,objs.Count * AddAlloc)];
      } else if (objs.Count > objArray.Length) {
        // The number of game objects has exceeded the array size.
        // Reallocate the array, adding 20% free space for further expansion.
        objArray = new GameObj[(int)(objs.Count * AddAlloc)];
      }

      // Store the current object count for performance
      var objectCount = objs.Count;

      // Transfer the object references into the array
      for (var i = 0; i < objArray.Length; i++) {
        // Is there an active object at this position in the GameObjects collection?
        if (i < objectCount) {
          // Yes, so copy it to the array
          objArray[i] = objs[i];
        } else {
          // No, so clear any reference stored at this index position
          objArray[i] = null;
        }
      }
    }

    public static void Add<T>(T obj) where T : GameObj {
      updateFlag = true;
      objs.Add(obj);
    }

    public static void AddRange<T>(List<T> objList) where T : GameObj {
      updateFlag = true;
      objs.AddRange(objList);
    }

    public static void Remove<T>(T obj) where T : GameObj {
      updateFlag = true;
      objs.Remove(obj);
    }

    public static void Clear() {
      updateFlag = true;
      objs.Clear();
    }

    public static List<GameObj> Get() {
      return objs;
    }

    /// <summary>
    /// Checks if the current object exists within the colection
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static bool Contains(Sprite obj) => objs.Contains(obj);

    /// <summary>
    ///   Call the Draw method on all SpriteObject-based objects in the game host
    ///   whose texture matches the one provided.
    /// </summary>
    /// <param name="gameTime"></param>
    /// <param name="spriteBatch"></param>
    public static void DrawSprites(GameTime gameTime, SpriteBatch spriteBatch) {
      foreach (var itm in objArray) {
        if (itm is Sprite sprite) {
          sprite.Draw(gameTime, spriteBatch);
        }
      }
    }

    /// <summary>
    /// If TRUE, there is an object at this location.
    /// </summary>
    /// <param name="tst"></param>
    /// <param name="pos"></param>
    /// <returns></returns>
    public static bool ObjsAtLocation(Sprite tst, Vector2 pos) {
      foreach (var obj in objs) {
        // Go through all of the game objects
        if (obj == tst) continue; // Don't test for itself
        if (!(obj is Sprite sprite)) continue; // is it a sprite object?
        if (sprite.LayerDepth > tst.LayerDepth) continue; // is the layer depth greater?
        //if (!sprite.Hitbox.Collision(pos)) continue; // Is there a collision?
        return true;
      }
      return false;
    }

    /// <summary>
    ///   Call the Update method on all objects in the GameObjects collection
    /// </summary>
    /// <param name="gameTime"></param>
    public static void Update(GameTime gameTime) {
      if (updateFlag) { // An update has been flagged
        UpdateArray(); // First, update the array
        updateFlag = false;
      }

      // Loop for each element within the array
      foreach (var obj in objArray) {
        obj?.Update(gameTime); // Update the object
      }
    }
  }
}
