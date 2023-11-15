using AutoMapper;
using InsuranceSystem.Application.Interface;
using InsuranceSystem.Core.Dtos;
using InsuranceSystem.Domain.Policy;
using InsuranceSystem.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace InsuranceSystem.Infrastructure.Repositories
{
    public class PolicyHolderRepository : GenericRepository<PolicyHolder>, IPolicyHolderRepository
    {
        private IMapper _mapper;
        public PolicyHolderRepository(DatabaseContext db, IMapper mapper) : base(db) { _mapper = mapper; }

        public async Task<IEnumerable<PolicyHolderDto>> GetAllPolicies()
        {
            var policies = await FindAll(false).ToListAsync();
            return _mapper.Map<List<PolicyHolderDto>>(policies);
        }

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

        public void CreatePolicy(PolicyHolder policy) =>  Create(policy);
    }
}

