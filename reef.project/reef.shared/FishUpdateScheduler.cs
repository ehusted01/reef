using System;
using System.Collections.Generic;
using System.Text;

namespace reef.shared {
    public interface FishUpdateScheduler {
        // The amount of time between FishUpdate tasks
        public static readonly long JOB_INTERVAL = 10000;
        /// <summary>
        /// Schedules the FishUpdate task.
        /// </summary>
        public void Schedule();

        /// <summary>
        /// Returns whether or not the FishUpdate task is scheduled.
        /// </summary>
        /// <returns>true if the task is scheduled, false otherwise</returns>
        public bool IsScheduled();
    }
}
