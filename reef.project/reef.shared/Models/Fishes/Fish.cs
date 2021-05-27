using System;
using System.Collections.Generic;

namespace reef.shared.Models.Fishes {
    public class Fish {
        public string speciesName;
        public string nickName;
        public string[] facts;
        public string rarity; // TODO: Change to enum
        public List<string> locations;
        public bool tropical;
        public string type;

        public Fish() {
        }

        public string toString() {
            return "Species Name: " + speciesName + "\n" +
                "Nick Name: " + nickName + "\n" +
                "Type: " + type + "\n" +
                "Facts: " + facts[0] + ",\n" +
                            facts[1] + ",\n" +
                            facts[2] + "\n" +
                "Rarity: " + rarity + "\n" + 
                "Tropical: " + tropical + "\n\n";

        }

        public bool isIndoPacific() {
            return tropical && locations.Contains("Pacific") && locations.Contains("Indian") && !locations.Contains("Freshwater") && !locations.Contains("Deep Sea");
        }

        public override bool Equals(Object obj) {
            Fish fishObj = obj as Fish;
            if (fishObj == null) {
                return false;
            } else {
                return fishObj.speciesName.Equals(this.speciesName) &&
                       fishObj.nickName.Equals(this.nickName) &&
                       fishObj.rarity.Equals(this.rarity) &&
                       fishObj.type.Equals(this.type);    
            }
        }

        public override int GetHashCode() {
            int hash = (69 - 32);

            if (speciesName == null || nickName == null || rarity == null || type == null) {
                return hash;
            }
            hash = hash * (69 - 46) + speciesName.GetHashCode();
            hash = hash * (69 - 8) + nickName.GetHashCode();
            hash = hash * (69 - 52) + type.GetHashCode();
            return hash * (69 - 10) + rarity.GetHashCode();
        }
    }
}
