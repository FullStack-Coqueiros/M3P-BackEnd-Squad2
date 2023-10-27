using MedicalCare.Models;

namespace MedicalCare.Interfaces
{
    public interface ILogService
    {
        LogModel CreateLog(LogModel log);
        IEnumerable<LogModel> GetAllLogs();
    }
}