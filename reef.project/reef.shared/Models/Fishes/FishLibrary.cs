using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using reef.shared.Models.Device;

namespace reef.shared.Models.Fishes {
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

    /// <summary>
    /// Get all of the fish
    /// </summary>
    /// <returns></returns>
    public List<Fish> GetAll() {
      return allFish;
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
  }
}
