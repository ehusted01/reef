using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using reef.shared.Models.Device;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using reef.shared.Models.Fish;

namespace reef.shared.Models.ContentManagers
{
    public class FishManager
    {
        public FishManager()
        {
        }

        // private ContentManager content;
        // public Dictionary<string, Texture2D> Data = new Dictionary<string, Texture2D>();

        /// <summary>
        /// Load the game textures
        /// </summary>
        public void Load(GameIO gameIO) {
            FishLibrary fishLib = gameIO.ReadLocalJsonFile("fish.json");
            Console.WriteLine(fishLib.toString());
            Console.WriteLine(fishLib.fishCount());
        }
    }
}
