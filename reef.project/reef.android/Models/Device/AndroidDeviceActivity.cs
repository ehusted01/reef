
#region Using statements

using System;
using System.Collections;
using System.Collections.Generic;
using reef.shared.Models.Device;

#endregion

namespace reef.android.Models.Device {

    public interface IDeviceActivity {
        // interface members
        Hashtable Get(IList<AppInfo> apps);
    }
    public class AndroidDeviceActivity : IDeviceActivity {
        
         public Hashtable Get(IList<AppInfo> apps) {
            throw new NotImplementedException();
        }

 
    }
}
