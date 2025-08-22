using AppLoggerLibraryCS;

namespace AppLoggerPostgres
{
    public class AppLogPostgreSQLManager : IAppLoger
    {
        private AppLoggerDbContext _context = new();

        public void LogAppData(AppDataInfo appDataInformation)
        {
            if (appDataInformation == null)
            {
                throw new ArgumentNullException(nameof(appDataInformation), "AppDataInformation cannot be null");
            }

            var appDataLog = new Appdatalog
            {
                Appname = appDataInformation.AppName,
                Classname = appDataInformation.ClassName,
                Methodname = appDataInformation.MethodName,
                Message = appDataInformation.Message,
                Username = appDataInformation.UserName,
                Timestamp = DateTime.Now
            };

            _context.Appdatalogs.Add(appDataLog);
            _context.SaveChanges();
        }

        public void LogError(ErrorInfo errorInformation)
        {
            if (errorInformation == null)
            {
                throw new ArgumentNullException(nameof(errorInformation), "ErrorInformation cannot be null");
            }

            var errorLog = new Errorlog
            {
                Errormessage = errorInformation.ErrorMessage,
                Exceptiontype = errorInformation.ExceptionType.GetType().FullName,
                Stacktrace = errorInformation.StackTrace,
                Errortime = DateTime.Now
            };

            _context.Errorlogs.Add(errorLog);
            _context.SaveChanges();
        }
    }
}
