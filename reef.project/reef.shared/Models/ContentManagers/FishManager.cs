using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using reef.shared.Models.Device;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            StreamReader file = gameIO.ReadLocalJsonFile("fish.json");
            using (JsonTextReader reader = new JsonTextReader(file)) {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
            }

            // Data.Add("test", content.Load<Texture2D>("test"));
            /**
             * content.Load<Json>

            JObject o1 = JObject.Parse(File.ReadAllText(@"fish.json"));

            // read JSON directly from a file
            using (StreamReader file = File.OpenText(@"fish.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
            }
            /*
             * 
             * 


                namespace reef.android.Models.Fish {
                    public class FishParser {
                        public FishParser() {
                            JObject o1 = JObject.Parse(File.ReadAllText(@"fish.json"));

                            // read JSON directly from a file
                            using (StreamReader file = File.OpenText(@"fish.json"))
                            using (JsonTextReader reader = new JsonTextReader(file))
                            {
                                JObject o2 = (JObject)JToken.ReadFrom(reader);
                            }
                        }
                    }
                }

             * 
             * 
             */
        }
    }
}
