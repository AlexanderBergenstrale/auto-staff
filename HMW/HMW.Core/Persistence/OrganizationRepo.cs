using HMW.Core.Interfaces;
using HMW.Core.Models;

namespace HMW.Core.Persistence
{
    public class OrganizationRepo : MongoCollectionBase<Organization>, IOrganizationRepo
    {
        private const string COLLECTION_NAME = "Organizations";

        public OrganizationRepo(IDbConfig dbconfig) : base(dbconfig, COLLECTION_NAME) { }

    }
}
