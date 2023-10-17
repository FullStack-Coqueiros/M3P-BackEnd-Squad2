using MedicalCare.Interfaces;
using MedicalCare.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] LogModel logCreate)
        {
            var logModel = _logService.CreateLog(logCreate);
            return Ok(logModel);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var logs = _logService.GetAllLogs();
            return Ok(logs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var log = _logService.GetById(id);
            return Ok(log);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] LogModel logUpdate)
        {
            var logModel = _logService.GetById(id);
            if (logModel == null)
            {
                return NotFound();
            }
            _logService.UpdateLog(logUpdate);
            return Ok(logUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            bool response = _logService.DeleteLog(id);
            if (response == false)
            {
                return NotFound();
            }
            return Ok();

        }
    }
}
