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
            String speciesName = this.speciesName == null ? "" : this.speciesName;
            String nickName = this.nickName == null ? "" : this.nickName;
            String type = this.type == null ? "" : this.type;
            String factOne = facts == null || facts[0] == null ? "" : facts[0];
            String factTwo = facts == null || facts[1] == null ? "" : facts[1];
            String factThree = facts == null || facts[2] == null ? "" : facts[2];
            string rarity = this.rarity == null ? "" : this.rarity;

            return "Species Name: " + speciesName + "\n" +
                "Nick Name: " + nickName + "\n" +
                "Type: " + type + "\n" +
                "Facts: " + factOne + ",\n" +
                            factTwo + ",\n" +
                            factThree + "\n" +
                "Rarity: " + rarity + "\n" + 
                "Tropical: " + tropical + "\n\n";

        }

        public bool isIndoPacific() {
            if (locations == null) {
                return false;
            }
            return tropical && locations.Contains("Pacific") &&
                   locations.Contains("Indian") &&
                   !locations.Contains("Freshwater") &&
                   !locations.Contains("Deep Sea");
        }

        public override bool Equals(Object obj) {
            Fish fishObj = obj as Fish;
            if (fishObj == null || fishObj.speciesName == null ||
                fishObj.nickName == null || fishObj.rarity == null ||
                fishObj.type == null) {
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

            if (speciesName == null || nickName == null || rarity == null ||
                type == null) {
                return hash;
            }
            hash = hash * (69 - 46) + speciesName.GetHashCode();
            hash = hash * (69 - 8) + nickName.GetHashCode();
            hash = hash * (69 - 52) + type.GetHashCode();
            return hash * (69 - 10) + rarity.GetHashCode();
        }
    }
}
