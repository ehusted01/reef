using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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
        public void Load()
        {
            if (GameHost.Curr == null)
            {
                Console.WriteLine("Oops");
                return;

            }
            if (GameHost.Curr.GameIO == null)
            {
                Console.WriteLine("Oops");
                return;
            }
            StreamReader file = GameHost.Curr.GameIO.ReadLocalJsonFile("fish.json");
            using (JsonTextReader reader = new JsonTextReader(file))
            {
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
