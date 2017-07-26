/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2066
 *****************************************************************************************************
 * 所属域：ASTRONERGY
 * 登录用户：wei.zhan
 * CLR版本：4.0.30319.42000
 * 唯一标识：a14a50e7-4bd0-4aa1-8127-7952e821809b
 * 机器名称：HZCND-10401006
 * 联系人邮箱：zhanwei103@126.com
 *****************************************************************************************************
 * 命名空间：Logger
 * 类名称：WriteLogToWin
 * 文件名：WriteLogToWin
 * 创建时间：2017/7/25 15:26:38
 * 创建人：詹伟
 * 创建说明：
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    [Export(typeof(ILogger))]
    [ExportMetadata("Depict", "3")]
    class WriteLogToWin : ILogger
    {
        /// <summary>
        /// 写系统日志
        /// </summary>
        /// <param name="logInfo"></param>
        void ILogger.Write(LogInfo logInfo)
        {
            try
            {
                if (!EventLog.SourceExists(logInfo.AppName))
                {
                    EventLog.CreateEventSource(logInfo.AppName, logInfo.AppName);
                }
                string msg = string.Format("发生在[{0}]操作，\r\n内容：{1}", logInfo.Operate, logInfo.Content);
                EventLog.WriteEntry(logInfo.AppName, msg, GetLogEntryType(logInfo.Type), 1);
            }
            catch (SecurityException ex)
            {
                Debug.WriteLine("写入日志出错");
                throw ex;
            }
        }

        EventLogEntryType GetLogEntryType(LogType type)
        {
            Type t = typeof(EventLogEntryType);
            if (Enum.IsDefined(t, (int)type))
            { return (EventLogEntryType)Enum.Parse(t, ((int)type).ToString()); }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("LogType类型无法转换为EventLogEntryType类型");
                sb.AppendFormat("(LogType:{0})", type);
                throw new ApplicationException(sb.ToString());
            }
        }


    }
}
