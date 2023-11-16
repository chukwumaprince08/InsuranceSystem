using InsuranceSystem.Application.Interface;
using InsuranceSystem.Core.Dtos;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace InsuranceSystem.Application.Services.Policies
{
    [TestFixture]
	public class PolicyServiceTests
	{
        private AutoMocker _mocker;
        private PolicyService _policyService;

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMocker();
            _policyService = _mocker.CreateInstance<PolicyService>();
        }

        [Test]
        public async Task RepositoryMethodShouldReturnAllPolicies()
        {
            var response = new PolicyHolderDto();

            _mocker.GetMock<IPolicyHolderRepository>()
                   .Setup(x => x.GetAllPolicies())
                   .ReturnsAsync(new List<PolicyHolderDto> { response });

            var result = await _policyService.GetAllPolicies();

            Assert.That(result, Contains.Item(response));
        }

        [Test]
        public async Task RepositoryMethodShouldReturnSinglePolicyByPolicyId()
        {
            var response = new PolicyHolderDto();
            var policyId = 1;

            _mocker.GetMock<IPolicyHolderRepository>()
                    .Setup(x => x.GetById(policyId))
                    .ReturnsAsync(response);

            var result = await _policyService.GetById(policyId);

            Assert.That(result, Is.EqualTo(response));
        }

        [Test]
        public async Task RepositoryMethodShouldReturnPolicyByNationalID()
        {
            var response = new PolicyHolderDto();
            var nationalID = "NGN0014AA";

            _mocker.GetMock<IPolicyHolderRepository>()
                .Setup(x => x.GetByNationalID(nationalID))
                .ReturnsAsync(new List<PolicyHolderDto> { response});

            var result = await _policyService.GetByNationalID(nationalID);

            Assert.That(result, Contains.Item(response));
        }

        [Test]
        public async Task RepositoryMethodShouldReturnPolicyByPolicyNumber()
        {
            var response = new PolicyHolderDto();
            var policyNumber = "H2441";

            _mocker.GetMock<IPolicyHolderRepository>()
                    .Setup(x => x.GetByPolicyNumber(policyNumber))
                    .ReturnsAsync(response);

            var result = await _policyService.GetByPolicyNumber(policyNumber);

            Assert.That(result, Is.EqualTo(response));
        }

        [Test]
        public async Task RepositoryMethodShouldSuccessfullyCreatePolicy()
        {
            var request = new PolicyHolderDto();

            var date = DateTime.Now;

            _mocker.GetMock<IPolicyHolderRepository>()
                .Setup(x => x.CreatePolicy(request, date))
                .Returns(request);

            var result = await _policyService.CreatePolicy(request);

            Assert.That(result, Is.TypeOf(request.GetType()));
            Assert.IsNotNull(result);
        }
    }
}

