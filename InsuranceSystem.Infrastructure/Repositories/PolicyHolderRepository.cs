using InsuranceSystem.Core.Interface;
using InsuranceSystem.Domain.Policy;
using InsuranceSystem.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace InsuranceSystem.Infrastructure.Repositories
{
    public class PolicyHolderRepository : GenericRepository<PolicyHolder>, IPolicyHolderRepository
    {
        public PolicyHolderRepository(DatabaseContext db) : base(db) { }

        public async Task<PolicyHolder> GetByPolicyNumber(string policyNumber)
        {
            var request = await FindByCondition(x => x.PolicyNumber == policyNumber, true)
                                .FirstOrDefaultAsync();
            return request;
        }

        public async Task<IEnumerable<PolicyHolder>> GetByNationalID(string nationalId)
        {
            var request = await FindByCondition(x => x.NationalIDNumber == nationalId, true)
                                .ToListAsync();
            return request;
        }

        public async Task<PolicyHolder> GetById(int id)
        {
            var request = await FindByCondition(x => x.Id == id, true)
                .FirstOrDefaultAsync();
            return request;
        }
    }
}

