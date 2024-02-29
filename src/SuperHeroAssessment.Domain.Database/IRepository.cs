using MongoDB.Driver;
using System.Linq.Expressions;

namespace SuperHeroAssessment.Domain.Database
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> Query { get; set; }
        T Add(T entity);
        int Add(IEnumerable<T> entities);
        int Delete(Expression<Func<T, bool>> expression);
        bool Delete(T entity);
        void DeleteAll();
        T Single(Expression<Func<T, bool>> expression);
        IQueryable<T> FetchAll();
        IQueryable<T> FechAll(int page, int pagesize);
        IMongoCollection<T> GetCollection();
        T Update(string id, T entity);
        int UpdateMany(IEnumerable<T> entities);
    }
}
