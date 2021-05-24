using System;
using System.Collections.Generic;
using System.Linq;
namespace reef.shared.Models.Fish {
    public class Fish {
        public String speciesName;
        public String nickName;
        public String[] facts;
        public String rarity; // TODO: Change to enum
        public List<String> locations;
        public Boolean tropical;
        public String type;

        public Fish() {

        }

        public String toString() {
            return "Species Name: " + speciesName + "\n" +
                "Nick Name: " + nickName + "\n" +
                "Type: " + type + "\n" +
                "Facts: " + facts[0] + ",\n" +
                            facts[1] + ",\n" +
                            facts[2] + "\n" +
                "Rarity: " + rarity + "\n" + 
                "Tropical: " + tropical + "\n\n";

        }

        public Boolean isIndoPacific() {
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
