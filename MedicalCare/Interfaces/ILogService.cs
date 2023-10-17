using MedicalCare.Models;

namespace MedicalCare.Interfaces
{
    public interface ILogService
    {
        LogModel CreateLog(LogModel log);
        bool DeleteLog(int id);
        IEnumerable<LogModel> GetAllLogs();
        LogModel GetById(int id);
        LogModel UpdateLog(LogModel log);
    }
}