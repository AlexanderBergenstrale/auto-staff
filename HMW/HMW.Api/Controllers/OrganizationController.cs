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
    public class OrganizationController : ControllerBase
    {

        private readonly ILogger<OrganizationController> _logger;
        private readonly IOrganizationRepo orgRepo;

        public OrganizationController(ILogger<OrganizationController> logger, IOrganizationRepo orgRepo)
        {
            _logger = logger;
            this.orgRepo = orgRepo;
        }

        [HttpGet]
        public IEnumerable<Organization> Get()
        {
            return orgRepo.GetAll();
        }

        [HttpPost]
        public void Save(Organization organization)
        {
            orgRepo.Save(organization);
        }


    }
}
