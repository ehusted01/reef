using Android.App;
using Android.App.Job;
using Android.Content;
using reef.shared;
using System;

namespace reef.android {
    class AndroidFishUpdateScheduler : FishUpdateScheduler {
        private static readonly long JOB_INTERVAL = 86400000;
        public void Schedule() {
            Java.Lang.Class service = Java.Lang.Class.FromType(typeof(FishUpdateService));
            JobInfo.Builder jobBuilder = new JobInfo.Builder(314, new ComponentName(Application.Context, service));
            JobInfo fishUpdate = jobBuilder.SetBackoffCriteria(0, BackoffPolicy.Linear).SetPeriodic(JOB_INTERVAL).SetPersisted(true).Build();

            JobScheduler jobSched = (JobScheduler)Application.Context.GetSystemService(Context.JobSchedulerService);
            jobSched.Schedule(fishUpdate);
        }
    }
}