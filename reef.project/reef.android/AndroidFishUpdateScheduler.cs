using Android.App;
using Android.App.Job;
using Android.Content;
using reef.shared;
using System;

namespace reef.android {
    class AndroidFishUpdateScheduler : FishUpdateScheduler {
        /// <summary>
        /// How long the task can be delayed.
        /// </summary>
        private static readonly long EPSILON = 1000;

        /// <summary>
        /// Schedules the FishUpdate task as described in FishUpdateScheduler.
        /// </summary>
        public void Schedule() {
            // Construct a JobInfo that can be used to schedule the FishUpdate task
            Java.Lang.Class service = Java.Lang.Class.FromType(typeof(FishUpdateService));
            JobInfo.Builder jobBuilder = new JobInfo.Builder(314, new ComponentName(Application.Context, service));
            // The task should be run after JOB_INTERVAL time has passed and should try again asap if stopped
            JobInfo fishUpdate = jobBuilder.SetBackoffCriteria(0, BackoffPolicy.Linear).SetMinimumLatency(FishUpdateScheduler.JOB_INTERVAL).SetOverrideDeadline(FishUpdateScheduler.JOB_INTERVAL).Build();

            // Get the JobScheduler object and schedule the FishUpdate task
            JobScheduler jobSched = (JobScheduler)Application.Context.GetSystemService(Context.JobSchedulerService);
            int res = jobSched.Schedule(fishUpdate);
            if (res == JobScheduler.ResultFailure) {
                System.Diagnostics.Debug.WriteLine("FAILED_SCHEDULE");
            }
        }

        /// <summary>
        /// Returns whether or not the FishUpdate task is scheduled as described in FishUpdateScheduler.
        /// </summary>
        /// <returns>true if the task is scheduled, false otherwise</returns>
        public bool IsScheduled() {
            JobScheduler jobSched = (JobScheduler)Application.Context.GetSystemService(Context.JobSchedulerService);
            return jobSched.GetPendingJob(314) != null;
        }
    }
}