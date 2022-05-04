using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Job;

namespace Test.Schedule
{
    class Scheduler
    {
        private static IScheduler scheduler;
        public async Task StartAsync(int hour = 0, int minute = 0, Label lb = null)
        {
            await scheduler.Start();
            JobDataMap checkDoneJob = new JobDataMap();
            checkDoneJob.Put("Label", lb);

            /* Get update by day */
            if (hour == 0 && minute == 0)
            {
                IJobDetail jobUpdateVersion = JobBuilder.Create<StatusProcess>()
                .WithIdentity("jobUpdateVersion") // key
                .UsingJobData(checkDoneJob)
                .Build();

                ITrigger triggerUpdateVersion = CreateTrigger("triggerUpdateVersion", hour, minute);
                await scheduler.ScheduleJob(jobUpdateVersion, triggerUpdateVersion);
            }
            else
            {
                IJobDetail jobStatusProcess = JobBuilder.Create<StatusProcess>()
                .WithIdentity("jobStatusProcess") // key
                .UsingJobData(checkDoneJob)
                .Build();

                ITrigger triggerStatusProcess = CreateTrigger("triggerStatusProcess", hour, minute);
                await scheduler.ScheduleJob(jobStatusProcess, triggerStatusProcess);
            }

            return;
        }

        public async Task<bool> checkScheduleStartAsync()
        {
            scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            return scheduler.IsStarted;
        }

        public async Task StopAsync()
        {
            if (scheduler.IsStarted)
            {
                await scheduler.Shutdown();
            }
        }

        public async Task ResetSchedule(string keyTrigger, int hour = 0, int minute = 0)
        {
            ITrigger newTrigger = CreateTrigger(keyTrigger, hour, minute);
            await scheduler.RescheduleJob(new TriggerKey(keyTrigger), newTrigger);
        }

        private ITrigger CreateTrigger(string key, int hour, int minute)
        {
            if(hour != 0 && minute != 0)
            {
                return TriggerBuilder.Create()
                        .WithIdentity(key)
                        .StartAt(DateTime.Now)
                        .WithSimpleSchedule(x => x.WithIntervalInMinutes(5).RepeatForever())
                        .Build();
            }

            return TriggerBuilder.Create()
                        .WithIdentity(key)
                        .WithDailyTimeIntervalSchedule
                            (s =>
                                s.WithIntervalInHours(24)
                            .OnEveryDay()
                            .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(hour, minute)) // time can edit to your hobby
                            )
                        .Build();
        }
    }
}
