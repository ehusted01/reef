using System;
using System.IO;

// DO NOT DELETE THIS
namespace reef.shared.Models.Device {
    public abstract class GameIO {
        public abstract void ReadLocalJsonFile(string filePath, Action<StreamReader> cb);
    }
}