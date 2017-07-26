/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2066
 *****************************************************************************************************
 * 所属域：ASTRONERGY
 * 登录用户：wei.zhan
 * CLR版本：4.0.30319.42000
 * 唯一标识：32f03c3e-e20d-4411-93b9-dee7785b5290
 * 机器名称：HZCND-10401006
 * 联系人邮箱：zhanwei103@126.com
 *****************************************************************************************************
 * 命名空间：Logger
 * 类名称：DbContext
 * 文件名：DbContext
 * 创建时间：2017/7/22 15:00:13
 * 创建人：詹伟
 * 创建说明：MongoDb操作类
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Logger
{
    public class DbContext
    {
        private readonly MongoDatabase _db;

        public DbContext()
        {
            var client = new MongoClient("mongodb://10.121.2.90:27017");
            var server = client.GetServer();
            _db = server.GetDatabase("Log");
        }

        public MongoCollection<T> Collection<T>() where T : LogInfo
        {
            var collectionName = InferCollectionNameFrom<T>();
            return _db.GetCollection<T>(collectionName);
        }

        private static string InferCollectionNameFrom<T>()
        {
            var type = typeof(T);
            return type.Name;
        }

        private string ReadConnection()
        {
            string config = ConfigurationManager.AppSettings["WriteLogMethod"];
            return config;
        }
    }
}
