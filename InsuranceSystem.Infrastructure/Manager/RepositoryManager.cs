using InsuranceSystem.Core.Interface;
using InsuranceSystem.Infrastructure.DBContext;
using InsuranceSystem.Infrastructure.Repositories;

namespace InsuranceSystem.Infrastructure.Manager
{
    public class RepositoryManager : IRepositoryManager
	{
        private readonly DatabaseContext _db;
        private IPolicyHolderRepository _PolicyHolderRepository;

        public RepositoryManager(DatabaseContext db) => _db = db;

        public IPolicyHolderRepository PolicyHolder
        {
            get
            {
                if (_PolicyHolderRepository == null)
                    _PolicyHolderRepository = new PolicyHolderRepository(_db);
                return _PolicyHolderRepository;
            }
        }


        public async Task<int> SaveChangesAsync() => await _db.SaveChangesAsync();
    }
}

