using HMW.Core.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace HMW.Core.Persistence
{
    public class MongoCollectionBase<T> where T : ModelBase
    {
        private const string DATABASE_NAME = "automatedstaffing";
        protected readonly IMongoCollection<T> collection;

        public MongoCollectionBase(IDbConfig dbConfig, string collectionName)
        {
            var client = new MongoClient(dbConfig.ConnectionString);
            var db = client.GetDatabase(DATABASE_NAME);

            collection = db.GetCollection<T>(collectionName);
        }

        public T Get(string id)
        {
            return collection.Find<T>(o => o.Id.Equals(id)).FirstOrDefault();
        }
        public IList<T> GetAll()
        {
            return collection.Find<T>(o => true).ToList();

        }
        public void Save(T model)
        {
            collection.InsertOne(model);
        }
    }
}
