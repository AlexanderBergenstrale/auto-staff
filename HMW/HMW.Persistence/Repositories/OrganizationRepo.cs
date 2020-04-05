using HMW.Core.Interfaces;
using HMW.Core.Models;

namespace HMW.Persistence.Repositories
{
    public class OrganizationRepo : MongoCollectionBase<Organization>, IOrganizationRepo
    {
        private const string COLLECTION_NAME = "Organizations";

        public OrganizationRepo(IDbConfig dbconfig) : base(dbconfig, COLLECTION_NAME) { }

    }
}
