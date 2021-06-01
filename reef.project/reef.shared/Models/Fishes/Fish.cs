using System;
using System.Collections.Generic;

namespace reef.shared.Models.Fishes {
    public class Fish {
        public string speciesName;
        public string nickName;
        public string[] facts;
        public string rarity;
        public List<string> locations;
        public bool tropical;
        public string type;

        public Fish() {
        }

        /// <summary>
        /// Returns a string representation of a given fish.
        /// </summary>
        /// <returns>String containing fish's species name, nick name, type, rarity, and facts.</returns>
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

        /// <summary>
        /// Returns whether or not the Fish resides in a saltwater epipelagic or
        /// mesopelagic zone within the Indo-Pacific.
        /// </summary>
        /// <returns>true if the above conditions are met, false otherwise.</returns>
        public bool isIndoPacific() {
            if (locations == null) {
                return false;
            }
            return tropical && locations.Contains("Pacific") &&
                   locations.Contains("Indian") &&
                   !locations.Contains("Freshwater") &&
                   !locations.Contains("Deep Sea");
        }

        /// <summary>
        /// Returns whether or not this fish is equal to another object. Specifically
        /// tests species name, nick name, rarity, and type. 
        /// </summary>
        /// <returns>true if obj is a fish and matches this fish's species
        /// name, nick name, rarity, and type.</returns>
        public override bool Equals(Object obj) {
            Fish fishObj = obj as Fish;
            if (fishObj == null) {
                return false;
            } else {
                // If the speciesName of the parameter is null, or the two speciesNames
                // do not match, then return false
                if ((fishObj.speciesName == null && this.speciesName != null) ||
                    (fishObj.speciesName != null &&
                    !fishObj.speciesName.Equals(this.speciesName))) {
                    return false;
                }
                // See above comment, but for nickname
                if ((fishObj.nickName == null && this.nickName != null) ||
                    (fishObj.nickName != null &&
                    !fishObj.nickName.Equals(this.nickName))) {
                    return false;
                }
                if ((fishObj.rarity == null && this.rarity != null) ||
                    (fishObj.rarity != null &&
                    !fishObj.rarity.Equals(this.rarity))) {
                    return false;
                }
                if ((fishObj.type == null && this.type != null) ||
                    (fishObj.type != null &&
                    !fishObj.type.Equals(this.type))) {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Returns a hashcode for the given fish.
        /// </summary>
        /// <returns>An integer representation of this fish.</returns>
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
