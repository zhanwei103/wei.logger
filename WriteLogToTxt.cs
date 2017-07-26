/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2066
 *****************************************************************************************************
 * 所属域：ASTRONERGY
 * 登录用户：wei.zhan
 * CLR版本：4.0.30319.42000
 * 唯一标识：34e64fc3-7d2b-42a5-9a69-a776eaa1fd71
 * 机器名称：HZCND-10401006
 * 联系人邮箱：zhanwei103@126.com
 *****************************************************************************************************
 * 命名空间：Logger
 * 类名称：WriteLogToTxt
 * 文件名：WriteLogToTxt
 * 创建时间：2017/7/22 9:50:04
 * 创建人：詹伟
 * 创建说明：写入文本文件
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    [Export(typeof(ILogger))]
    [ExportMetadata("Depict", "1")]
    class WriteLogToTxt : ILogger
    {
        void ILogger.Write(LogInfo logInfo)
        {
#if DEBUG
            Console.WriteLine("开始 WriteLogToTxt");
#endif
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log", DateTime.Now.ToString("yyyy-MM"));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string filePath = Path.Combine(path, DateTime.Now.ToString("yyyy-MM-dd") + ".log");

                StreamWriter sw = File.AppendText(filePath);

                sw.Write(logInfo.ToString());
                sw.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
#if DEBUG
            Console.WriteLine("WriteLogToTxt 结束");
#endif
        }

    }
}
