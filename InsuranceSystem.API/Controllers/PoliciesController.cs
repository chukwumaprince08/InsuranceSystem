using InsuranceSystem.API.Dto;
using InsuranceSystem.Application.Services;
using InsuranceSystem.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyService _PolicyService;
        protected ResponseDto _response;

        public PoliciesController (IPolicyService policyService)
        {
            _PolicyService = policyService;
            _response = new ResponseDto();
        }

        [HttpGet("GetPolicies")]
        public async Task<ResponseDto> GetPolicies()
        {
            var policies = await _PolicyService.GetAllPolicies();
            _response.Result = policies;
            return _response;
        }

        [HttpGet("GetPolicyByPolicyNumber")]
        public async Task<ResponseDto> GetPolicyByPolicyNumber(string policyNumber)
        {
            try
            {
                var policy = await _PolicyService.GetByPolicyNumber(policyNumber);
                if (policy is null)
                {  
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Policy not found";
                    return _response;
                }
                _response.Result = policy;
                return _response;

            }
            catch (Exception ex)
            {
                // handle exception
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

        [HttpPost("CreatePolicy")]
        public async Task<ResponseDto> CreatePolicy([FromBody] PolicyHolderDto policyHolder)
        {
            if (!ModelState.IsValid)
            {
                _response.DisplayMessage = "Invalid Model";
                _response.IsSuccess = false;
                return _response;
            }

            try
            {
                var response = await _PolicyService.CreatePolicy(policyHolder);
                _response.Result = response;
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

