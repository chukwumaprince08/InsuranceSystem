using System;
using InsuranceSystem.Core.Dtos;

namespace InsuranceSystem.Application.Services.Claims
{
	public interface IClaimsService
	{
        Task<IEnumerable<ClaimsResponseDto>> GetAllClaims();
        Task<ClaimsResponseDto> GetById(string id);
        Task<ClaimsResponseDto> CreateClaim(ClaimsDto claimRequest);
        Task<ClaimsResponseDto> UpdateClaim(int id, string status);

    }
}

