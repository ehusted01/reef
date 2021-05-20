using Android.App;
using Android.App.Job;
using Android.Content;
using reef.shared.Controllers;
using reef.shared.Models;
using System.Threading.Tasks;

namespace reef.android {

    [Service(Name = "reef.android.reef.android.FishUpdateService",
         Permission = "android.permission.BIND_JOB_SERVICE")]
    public class FishUpdateService : JobService {
        public override bool OnStartJob(JobParameters jobParams) {
            Task.Run(() => {
                if (World.Curr == null) {
                    World w = new World();
                }

                World.Curr.Load();
                FishController fc = new FishController(World.Curr.DeviceActivity, World.Curr.Fishes);
                fc.UpdateFish();
                World.Curr.Save();

                //Send a notification
                NotificationManager nM = (NotificationManager) GetSystemService(Context.NotificationService);
                //nM.Notify(id, notification);
                // The job is finished
                JobFinished(jobParams, false);
            });

            // Keep running the job
            return true;
        }

        public override bool OnStopJob(JobParameters jobParams) {
            // Job must be completed so reschedule it
            return true;
        }
    }
}