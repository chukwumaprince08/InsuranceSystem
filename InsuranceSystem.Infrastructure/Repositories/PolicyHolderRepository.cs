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

        public async Task<PolicyHolderDto> GetByPolicyNumber(string policyNumber)
        {
            var response = await FindByCondition(x => x.PolicyNumber == policyNumber, true)
                                .FirstOrDefaultAsync();

            return _mapper.Map<PolicyHolderDto>(response);
        }

        // there are chances that a customer with nationalId could have more than once policies, hence we return a list
        public async Task<IEnumerable<PolicyHolderDto>> GetByNationalID(string nationalId)
        {
            var response = await FindByCondition(x => x.NationalIDNumber == nationalId, true)
                                .ToListAsync();
            return _mapper.Map<List<PolicyHolderDto>>(response);
        }

        public async Task<PolicyHolderDto> GetById(int id)
        {
            var response = await FindByCondition(x => x.Id == id, true)
                .FirstOrDefaultAsync();
            return _mapper.Map<PolicyHolderDto>(response);
        }

        public PolicyHolderDto CreatePolicy(PolicyHolderDto policyRequest, DateTime dateCreated)
        {
            var policy = _mapper.Map<PolicyHolder>(policyRequest);
            policy.DateCreated = policy.DateModified = dateCreated;

            Create(policy);
            
            return _mapper.Map<PolicyHolderDto>(policy);
        }
    }
}

