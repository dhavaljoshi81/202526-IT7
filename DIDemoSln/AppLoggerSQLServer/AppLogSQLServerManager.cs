using AppLoggerLibraryCS;

namespace AppLoggerSQLServer
{
    public class AppLogSQLServerManager : IAppLoger
    {
        private AppLoggerDbContext _context = new();
        public void LogAppData(AppDataInfo appDataInformation)
        {
            if (appDataInformation == null)
            {
                throw new ArgumentNullException(nameof(appDataInformation), "AppDataInformation cannot be null");
            }

            var appDataLog = new AppDataLog
            {
                AppName = appDataInformation.AppName,
                ClassName = appDataInformation.ClassName,
                MethodName = appDataInformation.MethodName,
                Message = appDataInformation.Message,
                UserName = appDataInformation.UserName,
                Timestamp = DateTime.Now
            };

            _context.AppDataLogs.Add(appDataLog);
            _context.SaveChanges();
        }

        public void LogError(ErrorInfo errorInformation)
        {
            if (errorInformation == null)
            {
                throw new ArgumentNullException(nameof(errorInformation), "ErrorInformation cannot be null");
            }

            var errorLog = new ErrorLog
            {
                ErrorMessage = errorInformation.ErrorMessage,
                ExceptionType = errorInformation.ExceptionType.GetType().FullName,
                StackTrace = errorInformation.StackTrace,
                ErrorTime = DateTime.Now
            };

            _context.ErrorLogs.Add(errorLog);
            _context.SaveChanges();
        }
    }    
}
