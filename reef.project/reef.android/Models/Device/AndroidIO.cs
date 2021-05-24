using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using Android.App;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using reef.shared.Models.Device;
using reef.shared.Models.Fish;

namespace reef.android.Models.Device
{
    public class AndroidIO : GameIO
    {
        private static readonly IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication();
        private static readonly JsonSerializer serializer = new JsonSerializer();

        public override FishLibrary ReadLocalJsonFile(string filePath)
        {
            using var isoStream = Application.Context.Assets.Open("fish.json");

            // if (!isoStore.FileExists(filePath)) return null; //NO, so do nothing
            // using var isoStream = new IsolatedStorageFileStream(filePath, FileMode.Open, isoStore);
            /*using (StreamReader reader = new StreamReader(isoStream))
            {
                string json = reader.ReadToEnd();
                Console.WriteLine(json);
                JObject items = JsonConvert.DeserializeObject(json);

            }*/
            StreamReader file = new StreamReader(isoStream);
            JsonTextReader reader = new JsonTextReader(file);
            JObject obj = null;
            using (reader) {
                obj = (JObject)JToken.ReadFrom(reader);
                // Console.WriteLine(o2);

                Console.WriteLine("Hello");
            }
            FishLibrary feesh = new FishLibrary();
            foreach (KeyValuePair<String, JToken> i in obj) {
                String type = i.Key;
                foreach(JObject j in i.Value) {
                    Boolean hasFacts = true;
                    String[] facts = new string[3];
                    for (int val = 0; val < 3; val++) {
                        if (((String)j["fun_facts"][val]).Equals("")) {
                            hasFacts = false;
                        } else {
                            facts[val] = (String)j["fun_facts"][val];
                        }
                    }
                    Boolean isTropical = (Boolean)j["tropical"];
                    List<String> locations = new List<String>();
                    foreach(String s in j["locations"]) {
                        locations.Add((String)s);
                    }
                    Fish f = new Fish();
                    f.tropical = isTropical;
                    f.locations = locations;
                    f.type = (String)type;
                    if (hasFacts && f.isIndoPacific()) {
                        f.speciesName = (String)j["species_name"];
                        f.nickName = (String)j["nick_name"];
                        f.facts = facts;
                        f.rarity = (String)j["rarity"];
                        feesh.addFish(f);
                    }
                }
            }
            return feesh;
        }
    }
}
