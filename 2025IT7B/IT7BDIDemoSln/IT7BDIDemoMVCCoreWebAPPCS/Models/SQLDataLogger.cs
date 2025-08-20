using IT7BDITestClassLibCS;

namespace IT7BDIDemoMVCCoreWebAPPCS.Models
{
    public class SQLDataLogger : IDataLogger
    {

        private It72025dbContext _dbContext;
        public SQLDataLogger(It72025dbContext it72025DbContext)
        {
             _dbContext = it72025DbContext;
        }
        public void LogData(string s)
        {
            DataLog dataLog = new DataLog();
            dataLog.DataValue = s;
            //Console.WriteLine(s + "--" + dataLog.DataValue);
            _dbContext.DataLogs.Add(dataLog);
            _dbContext.SaveChanges();
        }

        public void LogError(string s)
        {
            ErrorLog errorLog = new ErrorLog();
            errorLog.ErrorValue = s;
            _dbContext.ErrorLogs.Add(errorLog);
        }
    }
}
