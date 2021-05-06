using System;
using System.Collections.Generic;

namespace reef.shared.Models.Device {
    /// <summary>
    /// keeps track of an app (AppInfo) usage over the last 30 days.
    /// usage time is recorded in minutes.
    /// </summary>
    public class AppActivityLog {
        private static readonly int LOG_LENGTH = 30;  
        private double[] UsageLog;
        private int CurrPos;

        /// <summary>
        /// Constructor.
        /// </summary>
        public AppActivityLog() {
            UsageLog = new double[LOG_LENGTH];
            CurrPos = 0;
        }

        /// <summary>
        /// fills in CURRENT day activity, until present time.
        /// </summary>
        /// <param name="mins">
        /// minutes of usage.
        /// </param>
        public void LogUsage(double mins) {
            CurrPos = (CurrPos + 1) % LOG_LENGTH;
            UsageLog[CurrPos] = mins;
        }
       
        /// <returns>
        ///   
        /// </returns>
        public double GetTodayUsage() {
            return UsageLog[CurrPos];
        }

        //// <summary>
        /// gets the activity from previous week, EXCLUSIVE.
        /// </summary>
        /// <returns>
        /// activity on previous week.
        /// </returns>
        public double GetWeeklyUsage() {
            double totalMins = 0;
            ///
            if (CurrPos > 6) {
                for (int i = CurrPos - 7; i != CurrPos; i++) {
                    totalMins += UsageLog[i];
                }
            } else {
                int count;
                for (count = 0; count != CurrPos; count++) {
                    totalMins += UsageLog[count];
                }

                int pos = 23 + count;
                while (count < 7) {
                    totalMins += UsageLog[pos];
                    count++;
                }
            }
            return totalMins;
        }

        /// <summary>
        /// gets the activity from previous day, this many (daysAgo) days ago.
        /// </summary>
        /// <param daysAgo="daysAgo">
        /// days ago from today.
        /// <returns>
        /// activity on daysAgo.
        /// </returns>
        public double GetTodayUsage(int daysAgo) {
            int dayPos = CurrPos - daysAgo;
            if (dayPos < 0) {
                return UsageLog[(LOG_LENGTH - 1) - (dayPos * -1)];
            }
            return UsageLog[dayPos];
        }
    }
}
