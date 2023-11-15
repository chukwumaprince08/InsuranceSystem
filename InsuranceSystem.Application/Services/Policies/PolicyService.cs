using InsuranceSystem.Application.Interface;
using InsuranceSystem.Common.Dates;
using InsuranceSystem.Core.Dtos;
using InsuranceSystem.Core.Interface;

namespace InsuranceSystem.Application.Services
{
    public class PolicyService : IPolicyService
	{
		private IRepositoryManager _repoManager;
		private IPolicyHolderRepository _PolicyHolderRepo;
		private IDateService _Date;
		public PolicyService(IRepositoryManager repoManager, IPolicyHolderRepository policy, IDateService date)
		{
			_repoManager = repoManager;
			_PolicyHolderRepo = policy;
			_Date = date;
		}

        public async Task<IEnumerable<PolicyHolderDto>> GetAllPolicies()
			=> await _PolicyHolderRepo.GetAllPolicies();

		public async Task<PolicyHolderDto> GetByPolicyNumber(string policyNumber)
			=> await _PolicyHolderRepo.GetByPolicyNumber(policyNumber);

		public async Task<IEnumerable<PolicyHolderDto>> GetByNationalID(string nationalId)
			=> await _PolicyHolderRepo.GetByNationalID(nationalId);

		public async Task<PolicyHolderDto> GetById(int id)
			=> await _PolicyHolderRepo.GetById(id);

        public async Task<PolicyHolderDto> CreatePolicy(PolicyHolderDto policyRequest)
		{
			policyRequest.DateCreated = policyRequest.DateModified = _Date.GetDate();	// seting initial created date

			var policy = _PolicyHolderRepo.CreatePolicy(policyRequest);
			await _repoManager.SaveChangesAsync();
			return policy;
		}
    }
}

