using System;
using System.Collections.Generic;
using System.Text;

namespace reef.shared {
    public interface FishUpdateScheduler {
        /// <summary>
        /// Schedules the FishUpdate task.
        /// </summary>
        public void Schedule();
    }
}
