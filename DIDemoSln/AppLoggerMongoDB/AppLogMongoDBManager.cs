using AppLoggerLibraryCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLoggerMongoDB
{
    public class AppLogMongoDBManager : IAppLoger
    {
        private AppLoggerDbContext _dbContext;
        public AppLogMongoDBManager() 
        {
            _dbContext = new AppLoggerDbContext();    
        }
        public void LogAppData(AppDataInfo appDataInformation)
        {
            _dbContext.appDataInformation.InsertOne(appDataInformation);
        }

        public void LogError(ErrorInfo errorInformation)
        {
            _dbContext.errorInformation.InsertOne(errorInformation);
        }
    }
}
