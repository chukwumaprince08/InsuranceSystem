using AutoMapper;
using InsuranceSystem.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsuranceSystemController: ControllerBase
    {
        private readonly IRepositoryManager _Manager;
        private IMapper _Mapper;
        public InsuranceSystemController(IRepositoryManager manager, IMapper mapper)
        {
            _Manager = manager;
            _Mapper = mapper;
        }

        [HttpGet("GetPolicies")]
        public async Task<IActionResult> GetPolicies()
        {
            var policies = await _Manager.PolicyHolder.GetAllPolicies();
           
            return Ok(policies);
        }
    }
}

