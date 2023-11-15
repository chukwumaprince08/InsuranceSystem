using InsuranceSystem.Core.Dtos;

namespace InsuranceSystem.Application.Interface
{
    public interface IClaimsRepository
	{
        Task<IEnumerable<ClaimsDto>> GetClaimByNationalID(string nationalId);
        Task<IEnumerable<ClaimsResponseDto>> GetAllClaims();
        Task<ClaimsResponseDto> GetClaimById(string id);
        ClaimsResponseDto CreateClaim(ClaimsDto claimRequest, DateTime dateCreated);
        Task<ClaimsResponseDto> UpdateClaim(int id, string status);
    }
}

