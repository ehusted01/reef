using System;
using System.Collections.Generic;

namespace reef.shared.Models.Device {
    /// <summary>
    /// Keeps track of an app (AppInfo) usage over the last 30 queries.
    /// usage time is recorded as a ratio of "time in use : total time".
    /// </summary>
    public class AppActivityLog
    {
        /// <summary>
        /// Constant reprenting an entry that holds no data.
        /// </summary>
        public static readonly int NO_DATA = -1;

        /// <summary>
        /// The number of queries that can be stored in the log at a time.
        /// </summary>
        private static readonly int LOG_LENGTH = 30; 
        
        /// <summary>
        /// The array that holds the data.
        /// </summary>
        private double[] UsageLog;

        /// <summary>
        /// The current position in the array.
        /// </summary>
        private int CurrPos;

        /// <summary>
        /// Constructor. Initializes the log to NO_DATA.
        /// </summary>
        public AppActivityLog()
        {
            CurrPos = 0;
            UsageLog = new double[LOG_LENGTH];
            for (int i = 0; i < LOG_LENGTH; i++) {
                UsageLog[i] = NO_DATA;
            }
        }

        /// <summary>
        /// Fills in CURRENT query activity.
        /// </summary>
        /// <param name="usage">
        /// usage ratio.
        /// </param>
        public void LogUsage(double usage)
        {
            CurrPos = (CurrPos + 1) % LOG_LENGTH;
            UsageLog[CurrPos] = usage;
        }

        //// <summary>
        /// Gets the activity from previous week, EXCLUSIVE.
        /// </summary>
        /// <returns>
        /// activity on previous week.
        /// </returns>
        public double GetWeeklyUsage()
        {
            double totalMins = 0;

            if (CurrPos > 6)
            {
                for (int i = CurrPos - 7; i != CurrPos; i++)
                {
                    totalMins += UsageLog[i];
                }
            } else
            {
                int count;
                for (count = 0; count != CurrPos; count++)
                {
                    totalMins += UsageLog[count];
                }

                int pos = 23 + count;
                while (count < 7)
                {
                    totalMins += UsageLog[pos];
                    count++;
                }
            }
            return totalMins;
        }

        /// <summary>
        /// Gets the activity from previous query, this many (lastquery) queries ago.
        /// </summary>
        /// <param name="lastQuery">
        /// queries ago from most recent query.
        /// <returns>
        /// activity on lastQuery.
        /// </returns>
        public double GetUsage(int lastQuery)
        {
            if (lastQuery < 0) {
                throw new ArgumentException();
            }
            int dayPos = (LOG_LENGTH + CurrPos - lastQuery) % LOG_LENGTH;
            return UsageLog[dayPos];
        }
    }
}
