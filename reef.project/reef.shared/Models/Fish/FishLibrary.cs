using System;
using System.Collections.Generic;

namespace reef.shared.Models.Fish
{
    public class FishLibrary
    {
        public Dictionary<String, List<Fish>> fishRarityLib;
        public List<Fish> allFish;
        public Dictionary<String, List<Fish>> fishTypeLib;

        public FishLibrary()
        {
            fishRarityLib = new Dictionary<String, List<Fish>>();
            fishRarityLib.Add("Common", new List<Fish>());
            fishRarityLib.Add("Rare", new List<Fish>());
            fishRarityLib.Add("Uncommon", new List<Fish>());

            fishTypeLib = new Dictionary<String, List<Fish>>();
            fishTypeLib.Add("Cnidarians", new List<Fish>());
            fishTypeLib.Add("Crustaceans", new List<Fish>());
            fishTypeLib.Add("Ray-finned fish", new List<Fish>());
            fishTypeLib.Add("Mammals", new List<Fish>());
            fishTypeLib.Add("Mollusks", new List<Fish>());
            fishTypeLib.Add("Echinoderms", new List<Fish>());
            fishTypeLib.Add("Miscellaneous", new List<Fish>());
            fishTypeLib.Add("Sea sponges", new List<Fish>());
            fishTypeLib.Add("Sharks, rays and skates", new List<Fish>());
            fishTypeLib.Add("Extinct", new List<Fish>());

            allFish = new List<Fish>();
        }

        public void addFish(Fish fish)
        {
            if (fish.tropical && fish.isIndoPacific())
            {
                fishRarityLib[fish.rarity].Add(fish);
                fishTypeLib[fish.type].Add(fish);
                allFish.Add(fish);
            }
        }

        public Fish getCommonFish()
        {
            if (fishRarityLib["Common"].Count <= 0) {
                return null;
            }
            Random rand = new Random();
            return fishRarityLib["Common"][rand.Next(fishRarityLib["Common"].Count)];
        }

        public Fish getUncommonFish()
        {
            if (fishRarityLib["Common"].Count <= 0) {
                return null;
            }
            Random rand = new Random();
            return fishRarityLib["Uncommon"][rand.Next(fishRarityLib["Uncommon"].Count)];
        }

        public Fish getRareFish()
        {
            if (fishRarityLib["Common"].Count <= 0) {
                return null;
            }
            Random rand = new Random();
            return fishRarityLib["Rare"][rand.Next(fishRarityLib["Rare"].Count)];
        }

        public List<Fish> getAllFish() {
            List<Fish> fish = allFish;
            fish.Sort();
            return fish;
        }

        public Fish removeFish(Fish fish)
        {
            if (!allFish.Contains(fish))
            {
                return null;
            }
            allFish.Remove(fish);
            fishRarityLib[fish.rarity].Remove(fish);
            fishTypeLib[fish.type].Remove(fish);
            return fish;
        }

        public String toString() {
            String lib = "";
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
