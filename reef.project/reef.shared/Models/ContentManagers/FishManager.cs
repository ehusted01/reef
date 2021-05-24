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
            FishLibrary file = gameIO.ReadLocalJsonFile("fish.json");
            Console.Write(file.toString());
            /*JsonTextReader reader = new JsonTextReader(file);
            using (reader) {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
                Console.WriteLine(o2);
            }*/
            /*using (file)
            {
                string json = file.ReadToEnd();
                Console.WriteLine(json);
            }*/

            // https://stackoverflow.com/questions/15653921/get-current-folder-path
            // Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            // https://stackoverflow.com/questions/10962989/list-all-files-in-a-folder-full-path-of-the-file
            /*String[] files = Directory.GetFiles("~");
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine(files[i]);
            }*/

            // https://stackoverflow.com/questions/13297563/read-and-parse-a-json-file-in-c-sharp
            /*using (StreamReader r = new StreamReader(@"fish.json")) {
                string json = r.ReadToEnd();
                Console.WriteLine(json);
            }*/



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
