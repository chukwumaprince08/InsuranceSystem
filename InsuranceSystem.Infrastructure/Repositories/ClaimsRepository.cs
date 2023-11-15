using AutoMapper;
using InsuranceSystem.Application.Interface;
using InsuranceSystem.Common;
using InsuranceSystem.Core.Dtos;
using InsuranceSystem.Domain.Claims;
using InsuranceSystem.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace InsuranceSystem.Infrastructure.Repositories
{
    public class ClaimsRepository:  GenericRepository<Claim>, IClaimsRepository
	{
        private IMapper _mapper;
        public ClaimsRepository(DatabaseContext db, IMapper mapper) : base(db) { _mapper = mapper; }

        public async Task<IEnumerable<ClaimsResponseDto>> GetAllClaims()
        {
            var policies = await FindAll(false).ToListAsync();
            return _mapper.Map<List<ClaimsResponseDto>>(policies);
        }

        // there are chances that a customer with nationalId could have more than once policies, hence we return a list
        public async Task<IEnumerable<ClaimsDto>> GetClaimByNationalID(string nationalId)
        {
            var response = await FindByCondition(x => x.NationalIDOfPolicyHolder == nationalId, true)
                                .ToListAsync();
            return _mapper.Map<List<ClaimsDto>>(response);
        }

        public async Task<ClaimsResponseDto> GetClaimById(string id)
        {
            var response = await FindByCondition(x => x.ClaimsId == id, true)
                .FirstOrDefaultAsync();
            return _mapper.Map<ClaimsResponseDto>(response);
        }

        public ClaimsResponseDto CreateClaim(ClaimsDto claimRequest, DateTime dateCreated)
        {
            var claim = _mapper.Map<Claim>(claimRequest);
            claim.DateCreated = claim.DateModified = dateCreated;
            claim.ClaimsStatus = ClaimsStatusEnums.Submitted.ToString();
            claim.ClaimsId = $"CL{DateTime.Now.Ticks}_{claimRequest.NationalIDOfPolicyHolder.Substring(0,3)}";

            Create(claim);

            return _mapper.Map<ClaimsResponseDto>(claim);
        }

        public async Task<ClaimsResponseDto> UpdateClaim(int id, string status)
        {
            var claim = await FindByCondition(x => x.Id == id, false).FirstOrDefaultAsync();
            if (claim is null)
                return null;

            claim.ClaimsStatus = status;
            claim.DateModified = DateTime.Now;
            Update(claim);

            return _mapper.Map<ClaimsResponseDto>(claim);
        }
    }
}

