using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HMW.Core.Requests.Employee
{
    public class GetEmployeesByOrganizationIdRequest : IRequest<IList<Models.Employee>>
    {
        public string OrganizationId { get; set; }
    }
}
