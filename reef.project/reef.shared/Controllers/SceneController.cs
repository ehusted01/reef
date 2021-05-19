using System;
using System.Diagnostics;
using System.Collections.Generic;
using reef.shared.Views.Scenes;
using reef.shared.Models;

namespace reef.shared.Controllers {
  public static class SceneController {

    // The currently active game mode handler
    // A collection of all known game mode handler objects
    private static readonly Dictionary<Type, Scene> SceneHandlers = new Dictionary<Type, Scene>();

    /// <summary>
    /// The current game mode handler object
    /// </summary>
    public static Scene CurrentSceneHandler { get; private set; }

    /// <summary>
    /// The previous scene handled by the game
    /// </summary>
    public static Scene PrevScene { get; private set; }

    /// <summary>
    ///   Add a known GameMode handler to the class
    /// </summary>
    /// <param name="scene"></param>
    public static void AddSceneHandler(Scene scene) {
      var modeType = scene.GetType();

      // Does this mode already exist in the dictionary?
      if (SceneHandlers.ContainsKey(modeType)) {
        // Yes, so update the dictionary with the newly-provided instance
        SceneHandlers[modeType] = scene;
      } else {
        // No, so add to the dictionary with the game mode type name as the key
        SceneHandlers.Add(modeType, scene);
      }
    }

    /// <summary>
    /// Sets the game mode based on the Type of mode
    /// </summary>
    /// <param name="modeType"></param>
    public static void SetGameScene(Type modeType) {
      // If this is the current mode, do nothing
      if (CurrentSceneHandler != null && modeType == CurrentSceneHandler.GetType()) {
        return;
      }

      // Set the previous scene
      PrevScene = CurrentSceneHandler;

      // Leave the current mode
      CurrentSceneHandler?.Deactivate();

      // Select the new mode
      if (SceneHandlers.ContainsKey(modeType)) {
        CurrentSceneHandler = SceneHandlers[modeType];
      } else {
        // Don't know of any game mode handler with this name so deactivate the current mode handler
        Debug.WriteLine("Don't have this game scene: " + CurrentSceneHandler?.GetType());
        CurrentSceneHandler = null;
      }

      // Enter the new mode
      if (CurrentSceneHandler == null) return; // Nothing to do

      // Set this handler's list of game objects into the game itself
      GameHost.Curr.Objs.Add(CurrentSceneHandler.SceneObjs);
      GameHost.Curr.Objs.Add(CurrentSceneHandler.SceneObjs);

      // And activate it.
      CurrentSceneHandler.Activate();
    }

    /// <summary>
    /// Set the current game mode
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T SetGameScene<T>() where T : Scene {
      var modeType = typeof(T);
      SetGameScene(modeType);
      return CurrentSceneHandler as T;
    }

    /// <summary>
    ///   Retrieve the game mode handler for a specified game mode
    /// </summary>
    /// <returns></returns>
    public static T GetGameModeHandler<T>() where T : Scene {
      var modeType = typeof(T);

      // Does the handler collection contain a handler for this mode?
      if (SceneHandlers.ContainsKey(modeType)) {
        return SceneHandlers[modeType] as T; // Yes, so return it
      }
      return null; // No, so return null
    }
  }
}
