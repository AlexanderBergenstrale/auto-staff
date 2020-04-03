using HMW.Core.Interfaces;
using HMW.Core.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMW.Core.Persistence
{
    public class OrganizationRepo : IOrganizationRepo
    {
        // TODO: move to config and inject into constructor
        private string connstr = "";
        private const string DATABASE_NAME = "automatedstaffing";
        private const string COLLECTION_NAME = "Organizations";

        private readonly IMongoCollection<Organization> collection;

        public OrganizationRepo()
        {
            var client = new MongoClient(connstr);
            var db = client.GetDatabase(DATABASE_NAME);

            collection = db.GetCollection<Organization>(COLLECTION_NAME);
        }

        public Organization Get(int Id)
        {
            return collection.Find<Organization>(o => o.Id.Equals(Id)).FirstOrDefault();
        }
        public IList<Organization> GetAll()
        {
            return collection.Find<Organization>(o => true).ToList();

        }
        public void Save(Organization organization)
        {
            collection.InsertOne(organization);
        }
    }
}
