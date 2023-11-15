using InsuranceSystem.Core.Dtos;
using InsuranceSystem.Domain.Policy;

namespace InsuranceSystem.Application.Interface
{
    public interface IPolicyHolderRepository
    {
        Task<IEnumerable<PolicyHolderDto>> GetAllPolicies();
        Task<PolicyHolder> GetByPolicyNumber(string policyNumber);
        Task<IEnumerable<PolicyHolder>> GetByNationalID(string nationalId);
        Task<PolicyHolder> GetById(int id);
    }
}

