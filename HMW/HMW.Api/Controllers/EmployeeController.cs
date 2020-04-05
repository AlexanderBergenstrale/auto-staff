using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMW.Core;
using HMW.Core.Interfaces;
using HMW.Core.Models;
using HMW.Core.Notifications.Absence;
using HMW.Core.Requests;
using HMW.Core.Requests.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HMW.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly ILogger<EmployeeController> _logger;
        private readonly IDispatcher dispatcher;

        public EmployeeController(ILogger<EmployeeController> logger, IDispatcher dispatcher)
        {
            _logger = logger;
            this.dispatcher = dispatcher;
        }

        [HttpGet("{id}")]
        public Task<Employee> Get(string id)
        {
            return dispatcher.Send(new GetEmployeeByIdRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public void Save(CreateEmployeeRequest request)
        {
            dispatcher.Send(request);
        }

        [HttpGet("/organization/{id}/employees")]
        public Task<IList<Employee>> GetEmployeesByOrganizationId(string id)
        {
            return dispatcher.Send(new GetEmployeesByOrganizationIdRequest()
            {
                OrganizationId = id
            });
        }

        [HttpPost("/employee/{id}/absence")]
        public void SetAbsence(string id, CreateAbsenceNotification notification)
        {
            dispatcher.Dispatch(notification);
        }

    }
}
