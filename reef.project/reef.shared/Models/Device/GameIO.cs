﻿using System.IO;

// DO NOT DELETE THIS
namespace reef.shared.Models.Device {
    public abstract class GameIO {
        public abstract StreamReader ReadLocalJsonFile(string filePath);
    }
}