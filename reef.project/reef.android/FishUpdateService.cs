using Android.App;
using Android.App.Job;
using Android.Content;
using reef.shared.Controllers;
using reef.shared.Models;
using System.Threading.Tasks;

namespace reef.android {

    /// <summary>
    /// The FishUpdateService extends an Android JobService and is run when the user's FishCollection
    /// should be updated.
    /// </summary>
    [Service(Name = "reef.android.reef.android.FishUpdateService",
         Permission = "android.permission.BIND_JOB_SERVICE")]
    public class FishUpdateService : JobService {

        public override bool OnStartJob(JobParameters jobParams) {
            // Start a thread that performs the task
            Task.Run(() => {
                // If the current World is null, create one
                if (World.Curr == null) {
                    World w = new World();
                }

                // Load in the world and create a FishCollectionController to update the user's fish
                World.Curr.Load();
                FishCollectionController fcc = new FishCollectionController(World.Curr.DeviceActivity, World.Curr.Fishes);
                fcc.UpdateFish();
                // Save the World
                World.Curr.Save();

                // Schedule the next FishUpdate task
                AndroidFishUpdateScheduler sched = new AndroidFishUpdateScheduler();
                sched.Schedule();
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