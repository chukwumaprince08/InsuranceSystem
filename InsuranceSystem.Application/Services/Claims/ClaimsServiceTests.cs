using System;
using InsuranceSystem.Application.Interface;
using InsuranceSystem.Core.Dtos;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace InsuranceSystem.Application.Services.Claims
{
    [TestFixture]
	public class ClaimsServiceTests
	{
        private AutoMocker _mocker;
        private ClaimsService _claimsService;

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMocker();
            _claimsService = _mocker.CreateInstance<ClaimsService>();
        }

        [Test]
        public async Task RepositoryMethodShouldReturnAllClaims()
        {
            var response = new ClaimsResponseDto();

            _mocker.GetMock<IClaimsRepository>()
                   .Setup(x => x.GetAllClaims())
                   .ReturnsAsync(new List<ClaimsResponseDto> { response });

            var result = await _claimsService.GetAllClaims();

            Assert.That(result, Contains.Item(response));
        }

        [Test]
        public async Task RepositoryMethodShouldReturnSingleClaimByClaimsId()
        {
            var response = new ClaimsResponseDto();
            var claimsId = "CL001";

            _mocker.GetMock<IClaimsRepository>()
                    .Setup(x => x.GetClaimById(claimsId))
                    .ReturnsAsync(response);

            var result = await _claimsService.GetById(claimsId);

            Assert.That(result, Is.EqualTo(response));
        }

        [Test]
        public async Task RepositoryMethodShouldReturnClaimByNationalID()
        {
            var response = new ClaimsDto();
            var nationalID = "NGN0014AA";

            _mocker.GetMock<IClaimsRepository>()
                .Setup(x => x.GetClaimByNationalID(nationalID))
                .ReturnsAsync(new List<ClaimsDto> { response });

            var result = await _claimsService.GetClaimsByNationalID(nationalID);

            Assert.That(result, Contains.Item(response));
        }


        [Test]
        public async Task RepositoryMethodShouldSuccessfullyCreateClaim()
        {
            var request = new ClaimsDto();
            var expectedResponseType = new ClaimsResponseDto();

            var date = DateTime.Now;

            _mocker.GetMock<IClaimsRepository>()
                .Setup(x => x.CreateClaim(request, date))
                .Returns(expectedResponseType);

            var result = await _claimsService.CreateClaim(request);

            Assert.IsNotNull(result);
            Assert.That(result, Is.TypeOf(expectedResponseType.GetType()));
            Assert.That(result, Is.Not.TypeOf(request.GetType()));
        }

        [Test]
        public async Task RepositoryMethodShouldSuccessfullyUpdateClaims()
        {
            var expectedResponseType = new ClaimsResponseDto();
            var id = 1;
            var status = "Declined";

            _mocker.GetMock<IClaimsRepository>()
                .Setup(x => x.UpdateClaim(id, status))
                .ReturnsAsync(expectedResponseType);

            var result = await _claimsService.UpdateClaim(id, status);

            Assert.IsNotNull(result);
            Assert.That(result, Is.TypeOf(expectedResponseType.GetType()));
        }
    }
}

