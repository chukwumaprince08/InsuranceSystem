using InsuranceSystem.Domain.Common;
using InsuranceSystem.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace InsuranceSystem.Infrastructure.Repositories
{
    public class EFCoreRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public EFCoreRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }


        public void Add(T item)
        {
            _dbSet.Add(item);
        }

        public void Remove(T item) => _dbSet.Remove(item);

        public void Save() => _dbContext.SaveChanges();
    }
}

