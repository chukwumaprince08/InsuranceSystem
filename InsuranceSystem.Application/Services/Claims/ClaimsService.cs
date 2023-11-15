using InsuranceSystem.Application.Interface;
using InsuranceSystem.Common;
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


        public async Task<ClaimsResponseDto?> UpdateClaim(int id, string status)
        {
            var claimsStatus = ""; 

            if (id <= 0 || string.IsNullOrWhiteSpace(status))
                return null;

            switch (status)
            {
                case "Approved":
                case "APPROVED":
                    claimsStatus = ClaimsStatusEnums.Approved.ToString();
                    break;

                case "Declined":
                case "DECLINED":
                    claimsStatus = ClaimsStatusEnums.Declined.ToString();
                    break;

                case "In-Review":
                case "IN-REVIEW":
                    claimsStatus = ClaimsStatusEnums.InReview.ToString();
                    break;

                default:
                    // do nothing since we have retrieve the default value already
                    break;
            }

            if (string.IsNullOrWhiteSpace(claimsStatus))
                return null;

            var claim = await _ClaimsRepo.UpdateClaim(id, claimsStatus);
            if(claim is not null)
            {
                await _repoManager.SaveChangesAsync();
                return claim;
            }
            return null;
            
        }
        
    }
}

