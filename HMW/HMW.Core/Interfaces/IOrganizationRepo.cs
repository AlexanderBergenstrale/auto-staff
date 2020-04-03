using HMW.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMW.Core.Interfaces
{
    public interface IOrganizationRepo
    {
        IList<Organization> GetAll();
        Organization Get(int Id);
        void Save(Organization organization);
    }
}
