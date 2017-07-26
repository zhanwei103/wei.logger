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
 * 创建说明：写入MongoDb数据库
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
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Logger
{
    [Export(typeof(ILogger))]
    [ExportMetadata("Depict", "2")]
    class WriteLogToDb : ILogger
    {

        void ILogger.Write(LogInfo logInfo)
        {

#if DEBUG
            Console.WriteLine("开始WriteLogToDb");
#endif
            try
            {
                var db = new DbContext();
                var collection = db.Collection<LogInfo>();

                var results = collection.Insert(logInfo);
                Console.WriteLine(results.Ok);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            

#if DEBUG
            Console.WriteLine("WriteLogToDb,结果:{0}", results.Ok);
#endif
        }


    }
}
