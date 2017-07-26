/*****************************************************************************************************
 * 本代码版权归Quber所有，All Rights Reserved (C) 2017-2066
 *****************************************************************************************************
 * 所属域：ASTRONERGY
 * 登录用户：wei.zhan
 * CLR版本：4.0.30319.42000
 * 唯一标识：19fa2427-1447-4b86-8143-c7e008921ef0
 * 机器名称：HZCND-10401006
 * 联系人邮箱：zhanwei103@126.com
 *****************************************************************************************************
 * 命名空间：Logger
 * 类名称：BaseClass
 * 文件名：BaseClass
 * 创建时间：2017/7/22 9:51:31
 * 创建人：詹伟
 * 创建说明：基类，寻找插件
 *****************************************************************************************************
 * 修改人：
 * 修改时间：
 * 修改说明：
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class BaseClass
    {
        public BaseClass()
        {
            var catalog = new AggregateCatalog();
            //catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));

            if(File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logger.dll")))
            {
                var directoryCatalog = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory, "Logger.dll");
                catalog.Catalogs.Add(directoryCatalog);
            }
            else if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin\\Logger.dll")))
            {
                var directoryCatalog = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory, "bin\\Logger.dll");
                catalog.Catalogs.Add(directoryCatalog);
            }
            else {
                return;
            }
            //catalog.Catalogs.Add(new DirectoryCatalog("Logger")); 
            var _container = new CompositionContainer(catalog);

            _container.ComposeParts(this);
        }
    }
}
