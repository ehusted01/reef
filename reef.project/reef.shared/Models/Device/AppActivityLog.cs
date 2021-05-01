using System;
using System.Collections.Generic;

namespace reef.shared.Models.Device {
    public class AppActivityLog {
        private static readonly int LOG_LENGTH = 30;
        private double[] Log;
        private int CurrPos;

        public AppActivityLog() {
            Log = new double[LOG_LENGTH];
            CurrPos = 0;
        }
        public void LogUsage(double hours) {
            CurrPos = (CurrPos + 1) % LOG_LENGTH;
            Log[CurrPos] = hours;
        }
        public double GetUsage() {
            return Log[CurrPos];
        }
    }
}
