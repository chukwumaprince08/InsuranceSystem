using InsuranceSystem.API.Dto;
using InsuranceSystem.Application.Services;
using InsuranceSystem.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsuranceSystemController: ControllerBase
    {
        private readonly IPolicyService _PolicyService;
        protected ResponseDto _response;

        public InsuranceSystemController(IPolicyService policyService)
        {
            _PolicyService = policyService;
            _response = new ResponseDto();
        }

        [HttpGet("GetPolicies")]
        public async Task<object> GetPolicies()
        {
            var policies = await _PolicyService.GetAllPolicies();
            _response.Result = policies;
            return Ok(_response);
        }

        [HttpGet("GetPolicyByPolicyNumber")]
        public async Task<object> Get(string policyNumber)
        {
            try
            {
                var policy = await _PolicyService.GetByPolicyNumber(policyNumber);
                if (policy is null)
                    return NotFound();

                _response.Result = policy;
                return Ok(_response);

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
        public async Task<object> CreatePolicy([FromBody] PolicyHolderDto policyHolder)
        {
            try
            {

                var response = await _PolicyService.CreatePolicy(policyHolder);
                _response.Result = response;
                return CreatedAtAction("CreatePolicy", _response);
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

