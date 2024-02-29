using MongoDB.Bson;
using MongoDB.Driver;
using SuperHeroAssessment.Domain.Database.Attributes;
using SuperHeroAssessment.Domain.Database.Extensions;
using System.Linq.Expressions;
using System.Reflection;

namespace SuperHeroAssessment.Domain.Database
{
    public class MongoRepository<T> : IRepository<T> where T : Entity
    {
        private static IMongoClient _client;
        private readonly IMongoDatabase _database;

        public MongoRepository(IMongoClient client, MongoUrl url)
        {
            _client = client;
            _database = _client.GetDatabase(url.DatabaseName);
        }

        private static string GetCollectionNameFromInterface()
        {
            var att = CustomAttributeExtensions.GetCustomAttribute<CollectionName>(typeof(T).GetTypeInfo());

            return att?.Name ?? typeof(T).Name;
        }

        private static string GetCollectionNameFromType()
        {
            var type = typeof(T);
            string collectionName;

            var att = CustomAttributeExtensions.GetCustomAttribute<CollectionName>(typeof(T).GetTypeInfo());
            if (att != null)
            {
                collectionName = att.Name;
            }
            else
            {
                collectionName = type.Name;
            }
            return collectionName;
        }


        private string GetCollectionName()
        {
            var collectionName = typeof(T).GetTypeInfo().BaseType.Equals(typeof(object)) ?
                GetCollectionNameFromInterface() :
                GetCollectionNameFromType();

            if (string.IsNullOrEmpty(collectionName))
            {
                collectionName = typeof(T).Name;
            }

            return collectionName.ToLowerInvariant();
        }

        protected IMongoCollection<T> Collection
        {
            get => _database.GetCollection<T>(GetCollectionName());
            set => Collection = value;
        }

        public IQueryable<T> Query {
            get => Collection.AsQueryable<T>();
            set => Query = value;
        }

        public T Add(T entity)
        {
            Collection.InsertOne(entity);
            return entity;
        }

        public int Add(IEnumerable<T> entities)
        {
            Collection.InsertMany(entities);
            return entities.Count();
        }

        public int Delete(Expression<Func<T, bool>> expression)
        {
            int count = 0;
            foreach (var item in Query.Where(expression))
            {
                if (Delete(item))
                {
                    count++;
                }
            }
            return count;
        }

        public bool Delete(T entity)
        {
            var filter = Builders<T>.Filter.Eq("Id", new ObjectId(typeof(T).GetProperty("Id").GetValue(entity, null).ToString()));
            return Collection.DeleteOne(filter).DeletedCount == 1;
        }

        public void DeleteAll()
        {
            _database.DropCollection(GetCollectionName());
        }

        public IQueryable<T> FechAll(int page, int pageSize)
        {
            return PagingExtensions.Page(Query, page, pageSize);
        }

        public IQueryable<T> FetchAll()
        {
            return Query;
        }

        public IMongoCollection<T> GetCollection()
        {
            return Collection;
        }

        public T Single(Expression<Func<T, bool>> expression)
        {
            return Query.Where(expression).SingleOrDefault();
        }

        public T Update(string id, T entity)
        {
            Collection.ReplaceOne(Builders<T>.Filter.Eq(x => x.Id, id), entity, new ReplaceOptions { IsUpsert = true });
            return entity;
        }

        public int UpdateMany(IEnumerable<T> entities)
        {
            int count = 0;
            foreach(var entity in entities)
            {
                if (!string.IsNullOrEmpty(entity.Id))
                {
                    Collection.ReplaceOne(Builders<T>.Filter.Eq(y => y.Id, entity.Id), entity, new ReplaceOptions { IsUpsert = true });
                    count++;
                }
            }
            return count;
        }
    }
}
