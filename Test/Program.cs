using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            //LogInfo logInfo = new LogInfo()
            //{
            //    AppName = "appName1",
            //    Content = "content1",
            //    Type = LogType.Infomation,
            //    Operate = "operate1"
            //};

            //var demo = new WriteLog();
            //demo.Run(logInfo);


            ISearchLog demo = new SearchLog();
            List<LogInfo> logInfos = demo.QueryPageLogs("","",-1, "2017-07-22 16:37:39", "2017-07-22 17:50:36", "59730f04186e9b4c0ce9fb33",10, 1);

            Console.WriteLine("日志共有{0}条", logInfos.Count);
            foreach (LogInfo logInfo in logInfos)
            {
                Console.WriteLine(logInfo.ToString());
            }

 
            Console.ReadLine();
        }
    }
}
