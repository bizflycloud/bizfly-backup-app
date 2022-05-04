using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test.Job
{
    class StatusProcess : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                Process[] pr = Process.GetProcessesByName("bizfly-backup");

                if (pr.Any())
                {
                    JobDataMap dataMap = context.JobDetail.JobDataMap;
                    Label lb = (Label)dataMap.Get("Label");

                    foreach (Process item in pr)
                    {
                        if (item.Responding)
                        {
                            lb.Invoke((MethodInvoker)(() =>
                            {
                                lb.Text = "Đang chạy";
                            }));
                        }
                        else
                        {
                            lb.Invoke((MethodInvoker)(() =>
                            {
                                lb.Text = "Đang dừng";
                            }));
                        }

                        break;
                    }
                }
            }
            catch (Exception)
            {

            }

            return Task.CompletedTask;
        }
    }
}
