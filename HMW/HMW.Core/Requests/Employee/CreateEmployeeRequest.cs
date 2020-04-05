using HMW.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMW.Core.Requests.Employee
{
    public class CreateEmployeeRequest : IRequest
    {
        public string OrganizationId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
    }
}
