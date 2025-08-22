using AppLoggerLibraryCS;
using AppLoggerSQLServer;

IAppLoger appLoger = new AppLogSQLServerManager();

// Log application data
appLoger.LogAppData(new AppDataInfo
{
    AppName = "DITestConApp",
    ClassName = "Program",
    MethodName = "Main",
    Message = "Application started successfully.",
    UserName = Environment.UserName,
    Timestamp = DateTime.Now
});
