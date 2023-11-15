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
		public void TestShouldReturnListOfPolicies()
		{
			var policies = new PolicyHolderDto();

			 _mocker.GetMock<IPolicyService>()
				.Setup(x => x.GetAllPolicies())
				.ReturnsAsync(new List<PolicyHolderDto> { policies});

			var result = _controller.GetPolicies();

			Assert.That(result, Contains.Item(policies));
		}
	}
}

