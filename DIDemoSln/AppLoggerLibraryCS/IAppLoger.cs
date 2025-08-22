namespace AppLoggerLibraryCS
{
    public interface IAppLoger
    {
        void LogError(ErrorInfo errorInformation);
        void LogAppData(AppDataInfo appDataInformation);
    } 
}
