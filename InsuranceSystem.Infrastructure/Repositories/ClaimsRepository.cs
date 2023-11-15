using AutoMapper;
using InsuranceSystem.Application.Interface;
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

        public async Task<IEnumerable<ClaimsDto>> GetAllClaims()
        {
            var policies = await FindAll(false).ToListAsync();
            return _mapper.Map<List<ClaimsDto>>(policies);
        }

        // there are chances that a customer with nationalId could have more than once policies, hence we return a list
        public async Task<IEnumerable<ClaimsDto>> GetClaimByNationalID(string nationalId)
        {
            var response = await FindByCondition(x => x.NationalIDOfPolicyHolder == nationalId, true)
                                .ToListAsync();
            return _mapper.Map<List<ClaimsDto>>(response);
        }

        public async Task<ClaimsDto> GetClaimById(int id)
        {
            var response = await FindByCondition(x => x.Id == id, true)
                .FirstOrDefaultAsync();
            return _mapper.Map<ClaimsDto>(response);
        }

        public ClaimsDto CreateClaim(ClaimsDto claimRequest, DateTime dateCreated)
        {
            var claim = _mapper.Map<Claim>(claimRequest);
            claim.DateCreated = claim.DateModified = dateCreated;

            Create(claim);

            return _mapper.Map<ClaimsDto>(claim);
        }
    }
}

