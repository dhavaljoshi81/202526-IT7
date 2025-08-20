namespace IT7ADIDemoMVCCoreAppCS.Models
{
    public class SQLServerLogger : IDataLogger
    {
        private It72025dbContext dbContext;
        public SQLServerLogger(It72025dbContext context)
        {
            dbContext = context;  // ?? throw new ArgumentNullException(nameof(context), "It72025dbContext cannot be null.");
        }

        public void DataLog(string message)
        {
            DataLog dataLog = new DataLog();
            dataLog.DataValue = message;

            dbContext.DataLogs.Add(dataLog);
            dbContext.SaveChanges(); 
        }

        public void ErrorLog(string message)
        {
            ErrorLog errorLog = new ErrorLog();
            errorLog.ErrorValue = message;

            dbContext.ErrorLogs.Add(errorLog);
            dbContext.SaveChanges();
        }
    }    
}
