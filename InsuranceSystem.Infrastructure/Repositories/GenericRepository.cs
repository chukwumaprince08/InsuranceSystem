using System.Linq.Expressions;
using InsuranceSystem.Core.Interface;
using InsuranceSystem.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace InsuranceSystem.Infrastructure.Repositories
{
    public class GenericRepository<T> : IDisposable, IRepositoryBase<T> where T : class
    {
        protected DatabaseContext _db;
        
        public GenericRepository(DatabaseContext db) => _db = db;

        public void Create(T entity) => _db.Set<T>().Add(entity);

        public void Delete(T entity) => _db.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ? _db.Set<T>().AsNoTracking() : _db.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ? _db.Set<T>()
            .Where(expression)
            .AsNoTracking() : _db.Set<T>()
            .Where(expression);
        public void Update(T entity) => _db.Set<T>().Update(entity);


        public void Dispose()
        {
            _db.Dispose();
        }
    }
}

