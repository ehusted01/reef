using System;
using System.Collections.Generic;
using System.Text;
using reef.shared.Models.Device;

namespace reef.shared.Controllers {
    public class FishController {
        private IDeviceActivity UserActivity;
        // UserFish model here
        public FishController(IDeviceActivity activity/*, UserFish fish*/) {
            UserActivity = activity;
            // UserFish = fish;
        }

        public void UpdateFish() {
            UserActivity.Record();
            // Get activity and compare to previous
            // Update UserFish model
        }
    }
}
