using InsuranceSystem.Application.Services;
using InsuranceSystem.Core.Dtos;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace InsuranceSystem.API.Controllers
{
    [TestFixture]
	public class PoliciesControllerTests
	{
		private AutoMocker _mocker;
		private PoliciesController _controller;

		[SetUp]
		public void SetUp()
		{
			_mocker = new AutoMocker();
			_controller = _mocker.CreateInstance<PoliciesController>();
		}

		[Test]
		public async Task TestShouldReturnListOfPolicies()
		{
			
			var response = new PolicyHolderDto();

			_mocker.GetMock<IPolicyService>()
					.Setup(x => x.GetAllPolicies())
					.ReturnsAsync(new List<PolicyHolderDto> { response });

			
			var result = await _controller.GetPolicies();

			Assert.That(result.Result, Contains.Item(response));
		}

		[Test]
		public async Task TestShouldReturnSinglePolicy()
		{
			var response = new PolicyHolderDto();

			_mocker.GetMock<IPolicyService>()
					.Setup(x => x.GetByPolicyNumber("H2441"))
					.ReturnsAsync(response);


			var result = await _controller.GetPolicyByPolicyNumber("H2441");

			Assert.That(result.Result, Is.EqualTo(response));
		}

		[Test]
		public async Task TestShouldCreatePolicy()
		{
			var policy = new PolicyHolderDto();

			var result =  await _controller.CreatePolicy(policy);

			_mocker.GetMock<IPolicyService>()
					.Verify(x => x.CreatePolicy(policy), Times.Once);
			
			Assert.That(result.IsSuccess, Is.True);
			
		}
	}
}

