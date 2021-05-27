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
    }
}
