using InsuranceSystem.Application.Interface;
using InsuranceSystem.Common.Dates;
using InsuranceSystem.Core.Dtos;
using InsuranceSystem.Core.Interface;

namespace InsuranceSystem.Application.Services.Claims
{
    public class ClaimsService : IClaimsService
	{
        private readonly IRepositoryManager _repoManager;
        private readonly IClaimsRepository _ClaimsRepo;
        private readonly IDateService _Date;
        public ClaimsService(IRepositoryManager repoManager, IClaimsRepository claims, IDateService date)
        {
            _repoManager = repoManager;
            _ClaimsRepo = claims;
            _Date = date;
        }

        public async Task<IEnumerable<ClaimsResponseDto>> GetAllClaims()
            => await _ClaimsRepo.GetAllClaims();

        public async Task<ClaimsResponseDto> GetById(string id)
            => await _ClaimsRepo.GetClaimById(id);

        public async Task<ClaimsResponseDto> CreateClaim(ClaimsDto claimRequest)
        {
            var currentDate = _Date.GetDate();
            var claim = _ClaimsRepo.CreateClaim(claimRequest, currentDate);
            await _repoManager.SaveChangesAsync();
            return claim;
        }
    }
}

