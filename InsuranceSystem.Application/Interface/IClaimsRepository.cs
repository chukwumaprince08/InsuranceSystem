using InsuranceSystem.Core.Dtos;

namespace InsuranceSystem.Application.Interface
{
    public interface IClaimsRepository
	{
        Task<IEnumerable<ClaimsDto>> GetClaimByNationalID(string nationalId);
        Task<IEnumerable<ClaimsDto>> GetAllClaims();
        Task<ClaimsDto> GetClaimById(int id);
        ClaimsDto CreateClaim(ClaimsDto claimRequest, DateTime dateCreated);
    }
}

