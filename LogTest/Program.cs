using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace LogTest
{
    class Program
    {
        static void Main(string[] args)
        {
            LogInfo logInfo = new LogInfo()
            {
                AppName = "appName1",
                Content = "content1打发ad",
                Type = LogType.Warnning,
                Operate = "Operate"
            };

            var w = new WriteLog();
            w.Run(logInfo);

            //日志查询
            //var demo = new SearchLog();
            //List<LogInfo> logInfos = demo.QueryLogInfos("", "", -1, "2017-07-22 16:37:39", "2017-07-22 17:50:36");

            //Console.WriteLine("日志共有{0}条", logInfos.Count);
            //foreach (LogInfo logInfo in logInfos) {
            //    Console.WriteLine(logInfo.ToString());
            //}

            //分页查询
            var demo = new SearchLog();
            List<LogInfo> logInfos = demo.QueryPageLogs(-1, "2017-07-22 16:37:39", "2017-07-22 17:50:36", "59730f04186e9b4c0ce9fb33", 5, 1);

            Console.WriteLine("日志共有{0}条", logInfos.Count);
            foreach (LogInfo log in logInfos)
            {
                Console.WriteLine(log.ToString());
            }

            //IWriteLog w = new WriteLog();
            //w.Run(new LogInfo());

            Console.ReadLine();
        }
    }
}
