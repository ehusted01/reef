using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using reef.shared.Models.Device;

namespace reef.shared.Models.Fish {
  public class FishLibrary {
    public Dictionary<string, List<Fish>> fishRarityLib;
    public List<Fish> allFish;
    public Dictionary<string, List<Fish>> fishTypeLib;

    public FishLibrary() {
      fishRarityLib = new Dictionary<string, List<Fish>>();
      fishRarityLib["Common"] = new List<Fish>();
      fishRarityLib["Rare"] = new List<Fish>();
      fishRarityLib["Uncommon"] = new List<Fish>();

      // TODO
      fishRarityLib = new Dictionary<string, List<Fish>>();
      fishRarityLib["Cnidarians"] = new List<Fish>();
      // fishRarityLib[""] = new List<Fish>();
      fishRarityLib[""] = new List<Fish>();

      allFish = new List<Fish>();
    }

    public void addFish(Fish fish) {
      if (fish.tropical && fish.isIndoPacific())
      {
          // fishRarityLib[fish.rarity].Add(fish);
          // fishTypeLib[fish.type].Add(fish);
          allFish.Add(fish);
      }
    }

    public Fish getCommonFish()
    {
        Random rand = new Random();
        return fishRarityLib["Common"][rand.Next(fishRarityLib["Common"].Count)];
    }

    public Fish getUncommonFish()
    {
        Random rand = new Random();
        return fishRarityLib["Uncommon"][rand.Next(fishRarityLib["Uncommon"].Count)];
    }

    public Fish getRareFish()
    {
        Random rand = new Random();
        return fishRarityLib["Rare"][rand.Next(fishRarityLib["Rare"].Count)];
    }

    public Fish removeFish(Fish fish)
    {
        // TODO: May not 
        if (!allFish.Contains(fish))
        {
            return null;
        }
        allFish.Remove(fish);
        fishRarityLib[fish.rarity].Remove(fish);
        fishTypeLib[fish.type].Remove(fish);
        return fish;
    }

    public string toString() {
      string lib = "";
        foreach (Fish f in allFish) {
            lib = lib + f.toString();
        }
        return lib;
    }

    public int fishCount() {
        return allFish.Count;
    }

    public void Load(GameIO gameIO, string fileName) {
      StreamReader file = gameIO.ReadLocalJsonFile(fileName);
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
            addFish(f);
          }
        }
      }
    }
  }
}
