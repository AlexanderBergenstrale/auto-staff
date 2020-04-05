using HMW.Core.Interfaces;
using HMW.Core.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace HMW.Persistence.Repositories
{
    public class EmployeeRepo : MongoCollectionBase<Employee>, IEmployeeRepo
    {
        private const string COLLECTION_NAME = "Employee";
        public EmployeeRepo(IDbConfig dbconfig) : base(dbconfig, COLLECTION_NAME)  {  }

        public IList<Employee> GetByOrganizationId(string id)
        {
            return collection.Find(x => x.OrganizationId.Equals(id)).ToList();
        }
    }
}
