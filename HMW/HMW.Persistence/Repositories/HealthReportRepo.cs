using HMW.Core.Interfaces;
using HMW.Core.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMW.Persistence.Repositories
{
    public class HealthReportRepo : MongoCollectionBase<HealthReport>, IHealthReportRepo
    {
        private const string COLLECTION_NAME = "HealthReport";
        public HealthReportRepo(IDbConfig dbConfig) : base(dbConfig, COLLECTION_NAME) { }

        public IList<HealthReport> GetByEmployeeId(string id)
        {
            return collection.Find(x => x.EmployeeId.Equals(id)).ToList();
        }
    }
}
