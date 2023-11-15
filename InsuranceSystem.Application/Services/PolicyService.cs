using System;
using InsuranceSystem.Application.Interface;
using InsuranceSystem.Core.Dtos;
using InsuranceSystem.Core.Interface;

namespace InsuranceSystem.Application.Services
{
	public class PolicyServices : IPolicyService
	{
		private IRepositoryManager _repoManager;
		private IPolicyHolderRepository _PolicyHolderRepo;
		public PolicyServices(IRepositoryManager repoManager, IPolicyHolderRepository policy)
		{
			_repoManager = repoManager;
			_PolicyHolderRepo = policy;
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
			var policy = _PolicyHolderRepo.CreatePolicy(policyRequest);
			await _repoManager.SaveChangesAsync();
			return policy;
		}


    }
}

