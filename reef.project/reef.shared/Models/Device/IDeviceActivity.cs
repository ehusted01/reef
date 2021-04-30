#region Using statements
#endregion

using System.Collections;
using System.Collections.Generic;

namespace reef.shared.Models.Device {
 
    public interface IDeviceActivity {
        /// gets user-time-spent on "apps" starting from 00:00 to current time
        /// <summary>
        /// gets user-time-spent on "apps" starting from 00:00 to current time.
        /// </summary>
        /// <param name="apps">
        /// list of applications to get usage data on.
        /// </param>
        /// <returns>
        /// Activity<<AppInfo>, (hours, minutes, seconds)>.
        /// </returns>
        /// <exception cref="="ObjectNotFoundException"> 
        /// Thrown when "<appInfo>.name" is not installed.
        /// </exception>
        public abstract Hashtable Get(IList<AppInfo> apps);
  }
}
