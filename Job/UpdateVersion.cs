using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Helper;
using Test.Model;

namespace Test.Job
{
    class UpdateVersion : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                HttpClientHelper http = new HttpClientHelper();
                string json = await http.Get(@"https://backup-staging.bizflycloud.vn/dashboard/download-urls");
                TypeSystemModel mode = JsonHelper.ConvertToObject<TypeSystemModel>(json);
                
                if(mode?.lastest_version != null)
                {
                    if(mode.lastest_version != Form1._versionCurrent)
                    {
                        JobDataMap dataMap = context.JobDetail.JobDataMap;
                        Label lb = (Label)dataMap.Get("Label");

                        lb.Invoke((MethodInvoker)(() =>
                        {
                            lb.Text = "Đã có bản cập nhật mới";
                        }));
                    }
                }    
            }
            catch (Exception)
            {

            }

            return;
        }
    }
}
