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
    public class EmployeeController : ControllerBase
    {

        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeRepo repo;
        private readonly IOrganizationRepo orgRepo;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeRepo repo, IOrganizationRepo orgRepo)
        {
            _logger = logger;
            this.repo = repo;
            this.orgRepo = orgRepo;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return repo.GetAll();
        }

        [HttpGet("{id}")]
        public Employee Get(string id)
        {
            return repo.Get(id);
        }

        [HttpPost]
        public void Save(Employee employee)
        {
            // validate the organization exits
            if (string.IsNullOrEmpty(employee?.OrganizationId))
            {
                throw new Exception("OrganizationId is missing");
            }
            var org = orgRepo.Get(employee.OrganizationId);
            if (org == null || string.IsNullOrEmpty(org.Id))
            {
                throw new Exception("Invalid organization");
            }

            repo.Save(employee);
        }

        [HttpGet("/organization/{id}/employees")]
        public IEnumerable<Employee> GetEmployeesByOrganizationId(string id)
        {
            return repo.GetByOrganizationId(id);
        }

        [HttpPost("/employee/{id}/absence")]
        public void SetAbsence(string id, Absence model)
        {

        }

    }
}
