using HMW.Core.Interfaces;
using HMW.Core.Models;
using HMW.Core.Requests;
using HMW.Core.Requests.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HMW.Core.Handlers.Employee
{
    public class EmployeeHandler : IRequestHandler<CreateEmployeeRequest>,
                                   IRequestHandler<GetEmployeeByIdRequest, Models.Employee>,
                                   IRequestHandler<GetEmployeesByOrganizationIdRequest, IList<Models.Employee>>
    {
        private readonly IEmployeeRepo employeeRepo;
        private readonly IOrganizationRepo orgRepo;

        public EmployeeHandler(IEmployeeRepo employeeRepo, IOrganizationRepo orgRepo)
        {
            this.employeeRepo = employeeRepo;
            this.orgRepo = orgRepo;
        }

        public Task<Unit> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            // validate the organization exits
            if (string.IsNullOrEmpty(request?.OrganizationId))
            {
                throw new Exception("OrganizationId is missing");
            }
            var org = orgRepo.Get(request.OrganizationId);
            if (org == null || string.IsNullOrEmpty(org.Id))
            {
                throw new Exception("Invalid organization");
            }

            var employee = new Models.Employee()
            {
                Created = DateTime.Now,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                OrganizationId = request.OrganizationId,
                Skills = request.Skills
            };

            employeeRepo.Save(employee);

            return Task.FromResult(new Unit());
        }

        public Task<Models.Employee> Handle(GetEmployeeByIdRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(employeeRepo.Get(request.Id));
        }

        public Task<IList<Models.Employee>> Handle(GetEmployeesByOrganizationIdRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(employeeRepo.GetByOrganizationId(request.OrganizationId));
        }
    }
}
