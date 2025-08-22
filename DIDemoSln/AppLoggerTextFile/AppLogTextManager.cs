using AppLoggerLibraryCS;

namespace AppLoggerTextFile
{
    public class AppLogTextManager : IAppLoger
    {
        private readonly string _appLogFilePath = "app_log.txt";
        private readonly string _errorLogFilePath = "error_log.txt";
        private void LogAppMessage(string message)
        {
            using (var writer = new StreamWriter(_appLogFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }

        private void LogErrorMessage(string message)
        {
            using (var writer = new StreamWriter(_errorLogFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }

        public void LogAppData(AppDataInfo appDataInformation)
        {
            string str = appDataInformation.AppName
                + "," + appDataInformation.ClassName
                + "," + appDataInformation.MethodName
                + "," + appDataInformation.Message
                + "," + appDataInformation.UserName;
            LogAppMessage(str);
        }

        public void LogError(ErrorInfo errorInformation)
        {
            string str = errorInformation.ErrorMessage
                + "," + errorInformation.ExceptionType
                + "," + errorInformation.StackTrace;
            LogErrorMessage(str);
        }
    }
}
