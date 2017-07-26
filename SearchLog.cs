/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2066
 *****************************************************************************************************
 * 所属域：ASTRONERGY
 * 登录用户：wei.zhan
 * CLR版本：4.0.30319.42000
 * 唯一标识：7818a56d-8904-417e-a05c-4464bbc963f4
 * 机器名称：HZCND-10401006
 * 联系人邮箱：zhanwei103@126.com
 *****************************************************************************************************
 * 命名空间：Logger
 * 类名称：SearchLog
 * 文件名：SearchLog
 * 创建时间：2017/7/22 15:52:55
 * 创建人：詹伟
 * 创建说明：
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
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Logger
{
    public class SearchLog : ISearchLog
    {
        /// <summary>
        /// 条件查询，不分页
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="operate"></param>
        /// <param name="type"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<LogInfo> QueryLogInfos(string appName, string operate, int type, string startTime, string endTime)
        {
            var db = new DbContext();
            var collection = db.Collection<LogInfo>();
            IMongoQuery query = null;
            if (type != -1)
            {
                query = Query.And(Query.Matches("AppName", appName), Query.Matches("Operate", operate),
                    Query.EQ("Type", type), Query.GTE("Timestamp", startTime), Query.LTE("Timestamp", endTime));
            }
            else {
                query = Query.And(Query.Matches("AppName", appName), Query.Matches("Operate", operate),
                    Query.GTE("Timestamp", startTime), Query.LTE("Timestamp", endTime));
            }

            return collection.Find(query).ToList();
        }

        /// <summary>
        /// 只安日志类型及时间分页查询
        /// </summary>
        /// <param name="type"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="lastKeyValue"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortType"></param>
        /// <returns></returns>
        public List<LogInfo> QueryPageLogs(int type, string startTime, string endTime, string lastKeyValue, int pageSize, int sortType)
        {
            return QueryPageLogs("","",type,startTime,endTime,lastKeyValue,pageSize,sortType);
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="operate"></param>
        /// <param name="type"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="lastKeyValue"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<LogInfo> QueryPageLogs(string appName, string operate, int type, string startTime, string endTime, string lastKeyValue, int pageSize, int sortType)
        {
            IMongoQuery query = null;
            if (type != -1)
            {
                query = Query.And(Query.Matches("AppName", appName), Query.Matches("Operate", operate),
                    Query.EQ("Type", type), Query.GTE("Timestamp", startTime), Query.LTE("Timestamp", endTime));
            }
            else
            {
                query = Query.And(Query.Matches("AppName", appName), Query.Matches("Operate", operate),
                    Query.GTE("Timestamp", startTime), Query.LTE("Timestamp", endTime));
            }

            return Find(query, "_id", new ObjectId(lastKeyValue), pageSize, sortType);
        }

        /// <summary>
        /// 获取所有日志
        /// </summary>
        /// <returns></returns>
        public List<LogInfo> GetAllLogInfos()
        {
            var db = new DbContext();
            var collection = db.Collection<LogInfo>();

            return collection.FindAll().ToList<LogInfo>();
        }


        /// <summary>  
        /// 分页查询 指定索引最后项-PageSize模式   
        /// </summary>  
        /// <typeparam name="LogInfo">所需查询的数据的实体类型</typeparam>  
        /// <param name="query">查询的条件 没有可以为null</param>  
        /// <param name="indexName">索引名称</param>  
        /// <param name="lastKeyValue">最后索引的值</param>  
        /// <param name="pageSize">分页的尺寸</param>  
        /// <param name="sortType">排序类型 1升序 -1降序 仅仅针对该索引</param>  
        /// <returns>返回一个List列表数据</returns>  
        private List<LogInfo> Find(IMongoQuery query, string indexName, object lastKeyValue, int pageSize, int sortType)
        {
            try
            {
                var db = new DbContext();
                var collection = db.Collection<LogInfo>();

                MongoCursor<LogInfo> mongoCursor = null;
  
                //判断升降序后进行查询  
                if (sortType > 0)
                {
                    //升序  
                    if (lastKeyValue != null)
                    {
                        //有上一个主键的值传进来时才添加上一个主键的值的条件  
                        query = Query.And(query, Query.GT(indexName, BsonValue.Create(lastKeyValue)));
                    }
                    //先按条件查询 再排序 再取数  
                    mongoCursor = collection.Find(query).SetSortOrder(new SortByDocument(indexName, 1)).SetLimit(pageSize);
                }
                else
                {
                    //降序  
                    if (lastKeyValue != null)
                    {
                        query = Query.And(query, Query.LT(indexName, BsonValue.Create(lastKeyValue)));
                    }
                    mongoCursor = collection.Find(query).SetSortOrder(new SortByDocument(indexName, -1)).SetLimit(pageSize);
                }
                return mongoCursor.ToList<LogInfo>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
