using System;
using System.IO;
using reef.shared.Models.Fish;


// DO NOT DELETE THIS
namespace reef.shared.Models.Device {
    public abstract class GameIO {
        public abstract FishLibrary ReadLocalJsonFile(string filePath);
    }
}