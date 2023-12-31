﻿using MedicalCare.Interfaces;
using MedicalCare.Models;

namespace MedicalCare.Services
{
    public class LogService : ILogService
    {
        private readonly IRepository<LogModel> _logRepository;

        public LogService(IRepository<LogModel> logRepository)
        {
            _logRepository = logRepository;
        }

        public IEnumerable<LogModel> GetAllLogs()
        {
            return _logRepository.GetAll();
        }

        public LogModel CreateLog(LogModel log)
        {
            return _logRepository.Create(log);
            //fazer mapper antes de retornar
        }
    }
}
