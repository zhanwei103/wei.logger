# wei.logger
日志记录功能

#目前只支持三种日志方式 
PS:如果利用MonogDb记录日志的话必须按照MonGoDb数据库。

#配置文件
  <appSettings> 
    <!--写日志的方式，可配置1文本，2数据库(mongoDb),3系统日志默认值为1--> 
    <add key="WriteLogMethod" value="1,2"/> 
    <!--如果是要写入数据库，需要添加以下配置信息--> 
    <add key="MongoDbCon" value="mongodb://IP:27017"/> 
  </appSettings> 

C# Code 
#写日志 
	var demo = new WriteLog(); 
	demo.Run(logInfo); 

#日志查询，仅限mongoDb 
	var demo = new SearchLog(); 
	List<LogInfo> logInfos = demo.QueryPageLogs(params)