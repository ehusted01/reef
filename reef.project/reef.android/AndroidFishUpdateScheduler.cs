using Android.App;
using Android.App.Job;
using Android.Content;
using reef.shared;
using System;

namespace reef.android {
    class AndroidFishUpdateScheduler : FishUpdateScheduler {
        private static readonly long JOB_INTERVAL = 10000;
        public void Schedule() {
            Java.Lang.Class service = Java.Lang.Class.FromType(typeof(FishUpdateService));
            JobInfo.Builder jobBuilder = new JobInfo.Builder(314, new ComponentName(Application.Context, service));
            JobInfo fishUpdate = jobBuilder.SetBackoffCriteria(0, BackoffPolicy.Linear).SetMinimumLatency(JOB_INTERVAL-1000).SetOverrideDeadline(JOB_INTERVAL+1000).Build();

            JobScheduler jobSched = (JobScheduler)Application.Context.GetSystemService(Context.JobSchedulerService);
            int res = jobSched.Schedule(fishUpdate);
            if (res == JobScheduler.ResultFailure) {
                System.Diagnostics.Debug.WriteLine("FAILED_SCHEDULE");
            }
        }
    }
}