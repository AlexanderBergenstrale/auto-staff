using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMW.Core;
using HMW.Core.Interfaces;
using HMW.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HMW.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthReportController : ControllerBase
    {

        private readonly ILogger<HealthReportController> _logger;
        private readonly IHealthReportRepo repo;
        private readonly IEmployeeRepo employeeRepo;

        public HealthReportController(ILogger<HealthReportController> logger, IHealthReportRepo repo, IEmployeeRepo employeeRepo)
        {
            _logger = logger;
            this.repo = repo;
            this.employeeRepo = employeeRepo;
        }

        [HttpGet]
        public IEnumerable<HealthReport> Get()
        {
            return repo.GetAll();
        }

        [HttpGet("{id}")]
        public HealthReport Get(string id)
        {
            return repo.Get(id);
        }

        [HttpPost]
        public void Save(HealthReport healthReport)
        {
            // validate the organization exits
            if (string.IsNullOrEmpty(healthReport?.EmployeeId))
            {
                throw new Exception("EmployeeId is missing");
            }
            var emp = employeeRepo.Get(healthReport.EmployeeId);
            if (emp == null || string.IsNullOrEmpty(emp.Id))
            {
                throw new Exception("Unknown employee");
            }

            // validate status
            // TODO

            // set the created date
            healthReport.Created = DateTime.Now;

            repo.Save(healthReport);
        }

        [HttpGet("/employee/{id}/healthreport")]
        public IEnumerable<HealthReport> GetHealthReportByEmployeeId(string id)
        {
            return repo.GetByEmployeeId(id);
        }
    }
}
