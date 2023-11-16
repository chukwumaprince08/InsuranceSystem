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
        }

        /// <summary>
        /// Only administrative staff are allowed to view all claims
        /// </summary>
        /// <returns></returns>

        [HttpGet("GetClaims")]
        public async Task<ResponseDto> GetClaims()
        {
            if (string.IsNullOrWhiteSpace(TempAuth))
                TempAuth = Request.Headers["TempAuth"];

            if (string.IsNullOrWhiteSpace(TempAuth))
            {
                _response.DisplayMessage = "You are not authorised to access this resource";
                _response.IsSuccess = false;
                return _response;
            }

            var claims = await _ClaimsService.GetAllClaims();
            _response.Result = claims;
            return _response;
        }

        /// <summary>
        /// Users can use this method to get the status of their claim
        /// </summary>
        /// <param name="claimsId"></param>
        /// <returns></returns>
        [HttpGet("GetClaimsById")]
        public async Task<ResponseDto> GetClaimsById(string claimsId)
        {
            var claim = await _ClaimsService.GetById(claimsId);
            _response.Result = claim;
            return _response;
        }

        [HttpPost("CreateClaim")]
        public async Task<ResponseDto> CreateClaim([FromBody]ClaimsDto claims)
        {
            try
            {
                var response = await _ClaimsService.CreateClaim(claims);
                _response.Result = response;
                _response.DisplayMessage = $"Your claim was successfully submitted. " +
                                           $"Please use Claim Number {response?.ClaimsId} to track the status of your claim";
                return _response;
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
        public async Task<ResponseDto> UpdateClaim([FromBody] ClaimsStatusUpdateDto claimsRequest)
        {
            if (string.IsNullOrWhiteSpace(TempAuth))
                TempAuth = Request.Headers["TempAuth"];

            if (string.IsNullOrWhiteSpace(TempAuth))
            {
                _response.DisplayMessage = "You are not authorised to access this resource";
                _response.IsSuccess = false;
                return _response;
            }

            var claim = await _ClaimsService.UpdateClaim(claimsRequest.Id, claimsRequest.ClaimsStatus);
            if(claim is null)
            {
                _response = new ResponseDto
                {
                    DisplayMessage = "Invalid ClaimsID or ClaimsStatus supplied supplied. " +
                                      "Please check the ReadMe file for guide",
                    Result = null
                };
            }
            else
            {
                _response.DisplayMessage = "Successfully Updated claim";
            }
            _response.Result = claim;
            return _response;
        }
    }
}

