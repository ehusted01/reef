using System;
using System.Collections.Generic;
using System.Diagnostics;
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
      using var reader = new JsonTextReader(file);
      var obj = (JObject)JToken.ReadFrom(reader);
      foreach (KeyValuePair<string, JToken> i in obj) {
        var type = i.Key;
        foreach (var jToken in i.Value) {
          var j = (JObject) jToken;
          if (j == null) continue;
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
            locations.Add(s);
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
            Debug.WriteLine("Loaded: "+f.speciesName);
            feeeesh.addFish(f);
          }
        }
      }
    }

    public List<Fish> GetAll() {
      return feeeesh.GetAll();
    }

    public Fish Get(string rarity) {
      if (!GameHost.Curr.FishLibrary.HasFishOfRarity(rarity)) {
        return feeeesh.Get("Common");
      }

      return feeeesh.Get(rarity);
    }

    public Fish GetCommon() {
      return Get("Common");
    }

    public Fish GetUncommon() {
      return Get("Uncommon");
    }

    public Fish GetRare() {
      return Get("Rare");
    }

    public void Load(GameIO gameIO, string filename) {
      gameIO.ReadLocalJsonFile(filename, ParseJson);
    }   
  }
}
