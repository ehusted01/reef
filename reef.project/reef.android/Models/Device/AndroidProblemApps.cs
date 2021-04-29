using System;
using System.Collections.Generic;
using System.IO;
using reef.shared.Models.Device;

namespace reef.android.Models.Device {
    public class AndroidProblemApps : ProblemApps {
        private IList<AppInfo> apps;
        public AndroidProblemApps(String file) {
            apps = new List<AppInfo>();
            if (!File.Exists(file)) {
                File.Create(file);
            } else {
                //Parse CSV into apps
            }
        }
        public override IList<AppInfo> Get() {
            return apps;
        }
        public override void Add(AppInfo info) {
            throw new NotImplementedException();
        }
        public override void Remove(AppInfo info) {
            throw new NotImplementedException();
        }
    }
}