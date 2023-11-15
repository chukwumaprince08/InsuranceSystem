using InsuranceSystem.Core.Dtos;
using InsuranceSystem.Domain.Policy;

namespace InsuranceSystem.Application.Interface
{
    public interface IPolicyHolderRepository
    {
        Task<IEnumerable<PolicyHolderDto>> GetAllPolicies();
        Task<PolicyHolderDto> GetByPolicyNumber(string policyNumber);
        Task<IEnumerable<PolicyHolderDto>> GetByNationalID(string nationalId);
        Task<PolicyHolderDto> GetById(int id);

        PolicyHolderDto CreatePolicy(PolicyHolderDto policyRequest, DateTime dateCreated);
    }
}

