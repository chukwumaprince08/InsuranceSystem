using InsuranceSystem.API.Dto;
using InsuranceSystem.Application.Services.Claims;
using InsuranceSystem.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClaimsController: ControllerBase
	{
        private readonly IClaimsService _ClaimsService;
        protected ResponseDto _response;

        public ClaimsController(IClaimsService claimsService)
        {
            _ClaimsService = claimsService;
            _response = new ResponseDto();
        }

        // should only allow Administrators to view all claims
        [HttpGet("GeAllClaims")]
        public async Task<object> GeAllClaims()
        {
            var claims = await _ClaimsService.GetAllClaims();
            _response.Result = claims;
            return Ok(_response);
        }

        [HttpGet("GetClaimById")]
        public async Task<object> GetClaimsById(string claimsId)
        {
            var claim = await _ClaimsService.GetById(claimsId);
            _response.Result = claim;
            return Ok(_response);
        }

        [HttpPost("CreateClaim")]
        public async Task<object> CreateClaim([FromBody]ClaimsDto claims)
        {
            try
            {
                var response = await _ClaimsService.CreateClaim(claims);
                _response.Result = response;
                _response.DisplayMessage = $"Your claim was successfully submitted. " +
                                           $"Please use Claim Number {response.ClaimsId} to track the status of your claim";
                return CreatedAtAction("CreateClaim", _response);
            }
            catch (Exception ex)
            {
                // catch the error and log it
                var log = ex.Message;

                _response = new ResponseDto
                {
                    DisplayMessage = "An error occured",
                    IsSuccess = false,
                    Result = null
                };
            }
            return _response;
        }
    }
}

