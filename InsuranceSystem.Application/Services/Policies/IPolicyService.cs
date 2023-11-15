using InsuranceSystem.Core.Dtos;

namespace InsuranceSystem.Application.Services
{
    public interface IPolicyService
	{
        Task<IEnumerable<PolicyHolderDto>> GetAllPolicies();
        Task<PolicyHolderDto> GetByPolicyNumber(string policyNumber);
        Task<IEnumerable<PolicyHolderDto>> GetByNationalID(string nationalId);
        Task<PolicyHolderDto> GetById(int id);
        Task<PolicyHolderDto> CreatePolicy(PolicyHolderDto policyRequest);

    }
}

