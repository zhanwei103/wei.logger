/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2066
 *****************************************************************************************************
 * 所属域：ASTRONERGY
 * 登录用户：wei.zhan
 * CLR版本：4.0.30319.42000
 * 唯一标识：65f723df-f4b8-46fe-be70-d0f8839bb380
 * 机器名称：HZCND-10401006
 * 联系人邮箱：zhanwei103@126.com
 *****************************************************************************************************
 * 命名空间：Logger
 * 类名称：LogInfo
 * 文件名：LogInfo
 * 创建时间：2017/7/22 9:42:57
 * 创建人：詹伟
 * 创建说明：日志实体
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Logger
{
    /// <summary>
    /// 日志实体
    /// </summary>
    public class LogInfo
    {
        /// <summary>
        /// mongoDb id
        /// </summary>
        public ObjectId _id { get; set; }
        /// <summary>
        /// 应用程序名
        /// </summary>
        public string AppName { get; set; }
        /// <summary>
        /// 操作，方法名
        /// </summary>
        public string Operate { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        public string Directory { get; set; }
        /// <summary>
        /// 服务器IP地址
        /// </summary>
        public string ServerIp { get; set; }
        /// <summary>
        /// 服务器名称
        /// </summary>
        public string ServerName { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 日志类型
        /// </summary>
        public LogType Type { get; set; }

        

        /// <summary>
        /// 时间戳，自动生成
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// 重写方法，对象转字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string logInfo = string.Format(@"/**************开始****************/ \r\nId:{5}\r\nAppName:{0} \r\n
                                            Operate:{1}\r\nContent:{2}\r\nLogType:{3}\r\nTimestamp:{4}\r\n\r\n",
                AppName, Operate, Content, Type, Timestamp,_id);
            return logInfo;
        }
    }
    /// <summary>
    /// 日志类型
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// code:1
        /// </summary>
        Error=1,
        /// <summary>
        /// code:2
        /// </summary>
        Warnning = 2,
        /// <summary>
        /// code:4
        /// </summary>
        Infomation = 4,
    }
}
