using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using reef.shared.Models.Device;
using reef.shared.Models.Fishes;

namespace reef.shared.Controllers {
  public class FishController {
    public FishController(FishLibrary lib) {
      feeeesh = lib;
    }

    private FishLibrary feeeesh;

    /// <summary>
    /// Parses the JSON & populates our Fish Library
    /// </summary>
    /// <param name="file"></param>
    private void ParseJson(StreamReader file) {
      JsonTextReader reader = new JsonTextReader(file);
      JObject obj = null;
      using (reader) {
        obj = (JObject)JToken.ReadFrom(reader);
      }
      foreach (KeyValuePair<string, JToken> i in obj) {
        string type = i.Key;
        foreach (JObject j in i.Value) {
          bool hasFacts = true;
          string[] facts = new string[3];
          for (int val = 0; val < 3; val++) {
            if (((string)j["fun_facts"][val]).Equals("")) {
              hasFacts = false;
            }
            else {
              facts[val] = (string)j["fun_facts"][val];
            }
          }
          bool isTropical = (bool)j["tropical"];
          List<string> locations = new List<string>();
          foreach (string s in j["locations"]) {
            locations.Add((string)s);
          }
          Fish f = new Fish();
          f.tropical = isTropical;
          f.locations = locations;
          f.type = type;
          if (hasFacts && f.isIndoPacific()) {
            f.speciesName = (string)j["species_name"];
            f.nickName = (string)j["nick_name"];
            f.facts = facts;
            f.rarity = (string)j["rarity"];
            feeeesh.addFish(f);
          }
        }
      }
    }

    public List<Fish> GetAll() {
      return feeeesh.GetAll();
    }

    public Fish GetCommon() {
      return feeeesh.getCommonFish();
    }

    public void Load(GameIO gameIO) {
      gameIO.ReadLocalJsonFile("fish.json", ParseJson);
    }   
  }
}
