using AutoMapper;
using Azure;
using InsuranceSystem.Application.Services;
using InsuranceSystem.Core.Dtos;
using InsuranceSystem.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsuranceSystemController: ControllerBase
    {
        private readonly IPolicyService _PolicyService;
   
        public InsuranceSystemController(IPolicyService policyService) =>_PolicyService = policyService;

        [HttpGet("GetPolicies")]
        public async Task<IActionResult> GetPolicies()
        {
            var policies = await _PolicyService.GetAllPolicies();
            return Ok(policies);
        }

        [HttpGet("GetPolicyByPolicyNumber")]
        public async Task<object> Get(string policyNumber)
        {
            try
            {
                var policy = await _PolicyService.GetByPolicyNumber(policyNumber);
                if (policy is null)
                    return NotFound();

                return Ok(policy);

            }
            catch (Exception ex)
            {
                // handle exception
                var log = ex.Message;
            }
            return NotFound();
        }

        [HttpPost("CreatePolicy")]
        public async Task<IActionResult> CreatePolicy([FromBody] PolicyHolderDto policyHolder)
        {
            var response = await _PolicyService.CreatePolicy(policyHolder);

            return CreatedAtRoute("CreatePolicy", response);
        }
    }
}

