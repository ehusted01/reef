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
  public class GameObjs {
    /// <summary>
    /// A collection of all the game objects
    /// </summary>
    private GameObj[] objArray = new GameObj[0];

    /// <summary>
    /// How much to update the array allocation by
    /// </summary>
    private const float AddAlloc = 1.2f;

    /// <summary>
    /// Set to true when the obj list has been changed.
    /// </summary>
    private bool updateFlag;

    /// <summary>
    /// A list of active game objects.
    /// </summary>
    public List<GameObj> Objs = new List<GameObj>();

    /// <summary>
    /// Updates the entire array witht he game objects
    /// </summary>
    private void UpdateArray() {
      // First build our array of objects.
      // We will iterate across this rather than across the actual GameObjects
      // collection so that the collection can be modified by the game objects' code.
      // First of all, do we have an array?
      if (objArray == null) {
        // No, so allocate it.
        // Allocate 20% more objects than we currently have, or 20 objects, whichever is more
        objArray = new GameObj[(int)MathHelper.Max(20, Objs.Count * AddAlloc)];
      } else if (Objs.Count > objArray.Length) {
        // The number of game objects has exceeded the array size.
        // Reallocate the array, adding 20% free space for further expansion.
        objArray = new GameObj[(int)(Objs.Count * AddAlloc)];
      }

      // Store the current object count for performance
      var objectCount = Objs.Count;

      // Transfer the object references into the array
      for (var i = 0; i < objArray.Length; i++) {
        // Is there an active object at this position in the GameObjects collection?
        if (i < objectCount) {
          // Yes, so copy it to the array
          objArray[i] = Objs[i];
        } else {
          // No, so clear any reference stored at this index position
          objArray[i] = null;
        }
      }
    }

    /// <summary>
    /// Adds a object to our object collection
    /// </summary>
    /// <param name="obj"></param>
    public void Add<T>(T obj) where T : GameObj {
      Objs.Add(obj);
      updateFlag = true;
    }

    /// <summary>
    /// Add a range 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="objs"></param>
    public void Add<T>(List<T> objs) where T : GameObj {
      Objs.AddRange(objs);
      updateFlag = true;
    }

    /// <summary>
    /// Remove an object from our collection
    /// </summary>
    /// <param name="obj"></param>
    public void Remove<T>(T obj) where T : GameObj {
      Objs.Remove(obj);
      updateFlag = false;
    }

    /// <summary>
    /// Checks if the current object exists within the colection
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public bool Contains(Sprite obj) => Objs.Contains(obj);

    /// <summary>
    ///   Call the Draw method on all Sprite-based objects in the game host
    ///   whose texture matches the one provided.
    /// </summary>
    /// <param name="gameTime"></param>
    /// <param name="spriteBatch"></param>
    public void DrawSprites(GameTime gameTime, SpriteBatch spriteBatch) {
      foreach (var itm in objArray) {
        if (itm is Sprite sprite) {
          sprite.Draw(gameTime, spriteBatch);
        }
      }
    }

    /// <summary>
    /// Call the Update method on all objects in the GameObj collection
    /// </summary>
    /// <param name="gameTime"></param>
    public void Update(GameTime gameTime) {
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
