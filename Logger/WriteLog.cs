/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2066
 *****************************************************************************************************
 * 所属域：ASTRONERGY
 * 登录用户：wei.zhan
 * CLR版本：4.0.30319.42000
 * 唯一标识：a362dcbc-4095-403d-9268-80e9dd44d6c8
 * 机器名称：HZCND-10401006
 * 联系人邮箱：zhanwei103@126.com
 *****************************************************************************************************
 * 命名空间：Logger
 * 类名称：WriteLog
 * 文件名：WriteLog
 * 创建时间：2017/7/22 9:59:01
 * 创建人：詹伟
 * 创建说明：日志对外总入口
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    /// <summary>
    /// 写日志类
    /// </summary>
    public class WriteLog : BaseClass, IWriteLog
    {
        [ImportMany]
        IEnumerable<Lazy<ILogger, LogInterfaceDepict>> DoList;

        /// <summary>
        /// 日志入口函数
        /// </summary>
        /// <param name="logInfo"></param>
        public void Run(LogInfo logInfo)
        {
            logInfo.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); ;
            string[] logList=ReadXml();
            foreach (var _do in DoList.Where(item => Array.IndexOf(logList,item.Metadata.Depict)>-1))
            {
                _do.Value.Write(logInfo);
            }
        }

        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <returns></returns>
        string[] ReadXml()
        {
            //读取配置文件，如果没有配置，默认写入Txt文本
            string config = ConfigurationManager.AppSettings["WriteLogMethod"];
            if (string.IsNullOrEmpty(config))
            {
                string[] logList = new string[] { "1"};
                return logList;
            }
            else {
                string[] logList = config.Split(',');
                return logList;
            }
        }
    }
}
