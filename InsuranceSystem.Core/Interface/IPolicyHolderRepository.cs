using InsuranceSystem.Domain.Policy;

namespace InsuranceSystem.Core.Interface
{
    public interface IPolicyHolderRepository
    {
        Task<PolicyHolder> GetByPolicyNumber(string policyNumber);
        Task<IEnumerable<PolicyHolder>> GetByNationalID(string nationalId);
        Task<PolicyHolder> GetById(int id);
    }
}

