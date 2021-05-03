using System;
using System.Collections.Generic;

namespace reef.shared.Models.Device {
    /// <summary>
    /// keeps track of an app (AppInfo) usage over the last 30 days.
    /// </summary>
    public class AppActivityLog {
        private static readonly int LOG_LENGTH = 30;
        private double[] Log;
        private int CurrPos;

        /// <summary>
        /// Constructor.
        /// </summary>
        public AppActivityLog() {
            Log = new double[LOG_LENGTH];
            CurrPos = 0;
        }

        /// <summary>
        /// fills in current day activity, until present time.
        /// </summary>
        /// <param name="hours">
        /// hours of usage.
        /// </param>
        public void LogUsage(double hours) {
            CurrPos = (CurrPos + 1) % LOG_LENGTH;
            Log[CurrPos] = hours;
        }
       
        /// <returns>
        ///   
        /// </returns>
        public double GetUsage() {
            return Log[CurrPos];
        }
    }
}
