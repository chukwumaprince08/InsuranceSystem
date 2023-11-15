using InsuranceSystem.API.Dto;
using InsuranceSystem.API.Helper;
using InsuranceSystem.Application.Services.Claims;
using InsuranceSystem.Common;
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
        public string TempAuth = "";

        public ClaimsController(IClaimsService claimsService)
        {
            _ClaimsService = claimsService;
            _response = new ResponseDto();
            TempAuth = Request.GetHeader("TempAuth"); // i implemented this temporarily because this is a demo app
        }

        /// <summary>
        /// Only administrative staff are allowed to view all claims
        /// </summary>
        /// <returns></returns>
       
        [HttpGet("GeAllClaims")]
        public async Task<object> GeAllClaims()
        {
            if (string.IsNullOrWhiteSpace(TempAuth))
                return BadRequest("You are not authorised to access this resource");

            var claims = await _ClaimsService.GetAllClaims();
            _response.Result = claims;
            return Ok(_response);
        }

        /// <summary>
        /// Users can use this method to get the status of their claim
        /// </summary>
        /// <param name="claimsId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Only administrative staff is allowed to change the status of a claim
        /// </summary>
        /// <param name="claimsRequest"></param>
        /// <returns></returns>
        [HttpPut("UpdateClaim")]
        public async Task<object> UpdateClaim([FromBody] ClaimsStatusUpdateDto claimsRequest)
        {
            // temporal fix for authorized users
            if (string.IsNullOrWhiteSpace(TempAuth))
                return BadRequest("You are not authorised to access this resource");

            var claim = await _ClaimsService.UpdateClaim(claimsRequest.Id, claimsRequest.ClaimsStatus);
            if(claim is null)
            {
                _response = new ResponseDto
                {
                    DisplayMessage = "Invalid ClaimsID or ClaimsStatus supplied supplied. " +
                                      "Please check the ReadMe file for guide"
                };
            }
            _response.Result = claim;
            return _response;
        }
    }
}

