namespace IT7ADIDemoMVCCoreAppCS.Models
{
    public interface IDataLogger
    {
        void DataLog(string message);
        void ErrorLog(string message);
    }
}
