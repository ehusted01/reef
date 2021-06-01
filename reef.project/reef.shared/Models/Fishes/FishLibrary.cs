using System;
using System.Collections.Generic;
using System.Diagnostics;
using reef.shared.Utils;

namespace reef.shared.Models.Fishes {
    public class FishLibrary {
        public Dictionary<string, List<Fish>> fishRarityLib;
        public List<Fish> allFish;
        public Dictionary<string, List<Fish>> fishTypeLib;
        public const string CommonRarity = "Common";
        public const string UncommonRarity = "Uncommon";
        public const string RareRarity = "Rare";
        public FishLibrary() {
          fishRarityLib = new Dictionary<String, List<Fish>>();
          fishRarityLib.Add(CommonRarity, new List<Fish>());
          fishRarityLib.Add(RareRarity, new List<Fish>());
          fishRarityLib.Add(UncommonRarity, new List<Fish>());

          fishTypeLib = new Dictionary<String, List<Fish>> {
            {"Cnidarians", new List<Fish>()},
            {"Crustaceans", new List<Fish>()},
            {"Ray-finned fish", new List<Fish>()},
            {"Mammals", new List<Fish>()},
            {"Mollusks", new List<Fish>()},
            {"Echinoderms", new List<Fish>()},
            {"Miscellaneous", new List<Fish>()},
            {"Sea sponges", new List<Fish>()},
            {"Sharks, rays and skates", new List<Fish>()},
            {"Extinct", new List<Fish>()}
          };

          allFish = new List<Fish>();
        }

        /// <summary>
        /// If true, there are fish of this rarity in the library
        /// </summary>
        /// <param name="rarity"></param>
        /// <returns></returns>
        public bool HasFishOfRarity(string rarity) {
          return fishRarityLib[rarity].Count > 0;
        }

        /// <summary>
        /// Gets a specific fish of a specific rarity
        /// </summary>
        /// <param name="rarity"></param>
        /// <returns></returns>
        public Fish Get(string rarity) {
          if (!HasFishOfRarity(rarity)) throw new ArgumentOutOfRangeException("No fish of rarity: "+rarity);
          return fishRarityLib[rarity].Next();
        }

        public void addFish(Fish fish) {
            if (fish.tropical && fish.isIndoPacific()) {
                fishRarityLib[fish.rarity].Add(fish);
                fishTypeLib[fish.type].Add(fish);
                allFish.Add(fish);
            }
        }

        public Fish getCommonFish() {
            if (fishRarityLib[CommonRarity].Count <= 0) {
              throw new ArgumentOutOfRangeException("No common fish to get");
            }
            Random rand = new Random();
            return fishRarityLib[CommonRarity][rand.Next(fishRarityLib["Common"].Count)];
        }

        public Fish getUncommonFish() {
            if (fishRarityLib[UncommonRarity].Count <= 0) {
              throw new ArgumentOutOfRangeException("No uncommon fish to get");
            }
            Random rand = new Random();
            return fishRarityLib[UncommonRarity][rand.Next(fishRarityLib["Uncommon"].Count)];
        }

        public Fish getRareFish() {
            if (fishRarityLib[RareRarity].Count <= 0) {
              throw new ArgumentOutOfRangeException("No rare fish to get");
            }
            Random rand = new Random();
            return fishRarityLib[RareRarity][rand.Next(fishRarityLib["Rare"].Count)];
        }

        /// <summary>
        /// Get a list of all the fish
        /// </summary>
        /// <returns></returns>
        public List<Fish> GetAll() {
            return new List<Fish>(allFish);
        }

        public Fish removeFish(Fish fish) {
            if (!allFish.Contains(fish)) {
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