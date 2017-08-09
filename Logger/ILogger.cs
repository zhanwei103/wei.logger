/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2066
 *****************************************************************************************************
 * 所属域：ASTRONERGY
 * 登录用户：wei.zhan
 * CLR版本：4.0.30319.42000
 * 唯一标识：5f85ca52-ce2c-49dd-91bc-d61cec719c58
 * 机器名称：HZCND-10401006
 * 联系人邮箱：zhanwei103@126.com
 *****************************************************************************************************
 * 命名空间：Logger
 * 类名称：ILogger
 * 文件名：ILogger
 * 创建时间：2017/7/22 9:41:27
 * 创建人：詹伟
 * 创建说明：日志接口
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

namespace Logger
{
    /// <summary>
    /// 插件接口，写日志的实现可以多种，但不对外公开
    /// </summary>
    interface ILogger
    {
        void Write(LogInfo logInfo);
    }
    /// <summary>
    /// 写日志可供第三方调用
    /// </summary>
    public interface IWriteLog
    {
        void Run(LogInfo logInfo);
    }
    /// <summary>
    /// 查询日志只限MongoDb,可供第三方程序调用
    /// </summary>
    public interface ISearchLog
    {
        /// <summary>
        /// 按条件查询不分页
        /// </summary>
        /// <param name="appName">程序名称</param>
        /// <param name="operate">操作名称</param>
        /// <param name="type">日志类型</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        List<LogInfo> QueryLogInfos(string appName, string operate, int type, string startTime, string endTime);

        /// <summary>
        /// 只安日志类型及时间分页查询
        /// </summary>
        /// <param name="type">日志类型(0,1,2),-1代表不区分</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="lastKeyValue">上一页最后一条ID</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="sortType">排序1升序，-1降序</param>
        /// <returns></returns>
        List<LogInfo> QueryPageLogs(int type, string startTime, string endTime, string lastKeyValue, int pageSize, int sortType);
        
        /// <summary>
        /// 分页查询总
        /// </summary>
        /// <param name="appName">程序名称</param>
        /// <param name="operate">操作名称</param>
        /// <param name="type">日志类型(0,1,2),-1代表不区分</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="lastKeyValue">上一页最后一条ID</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="sortType">排序1升序，-1降序</param>
        /// <returns></returns>
        List<LogInfo> QueryPageLogs(string appName, string operate, int type, string startTime, string endTime, string lastKeyValue, int pageSize, int sortType);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="operate"></param>
        /// <param name="type"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="indexPage"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortType"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        List<LogInfo> QueryPageLogs(string appName, string operate, int type, string startTime, string endTime, int indexPage, int pageSize, int sortType, out int total);

        /// <summary>
        /// 查询所有日志
        /// </summary>
        /// <returns></returns>
        List<LogInfo> GetAllLogInfos();

    }
}
