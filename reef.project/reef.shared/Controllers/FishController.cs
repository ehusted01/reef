using System;
using System.Collections.Generic;
using System.Text;
using reef.shared.Models;
using reef.shared.Models.Device;

namespace reef.shared.Controllers {
    public class FishController {
        private IDeviceActivity UserActivity;
        private User Fish;
        public FishController(IDeviceActivity activity, User fish) {
            UserActivity = activity;
            Fish = fish;
        }

        public void UpdateFish() {
            UserActivity.Record(0);
            double usage = 0;
            double prevUsage = 0;
            foreach (AppInfo info in UserActivity.GetProblemApps()) {
                usage += UserActivity.GetPastDayStats(0);
                prevUsage += UserActivity.GetPastDayStats(1);
            }
            if (usage < prevUsage) {
                Fish.AddFish();
            } else {
                Fish.RemoveFish();
            }        
        }
    }
}
