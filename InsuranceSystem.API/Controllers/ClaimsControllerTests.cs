using InsuranceSystem.API.Dto;
using InsuranceSystem.Application.Services.Claims;
using InsuranceSystem.Core.Dtos;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace InsuranceSystem.API.Controllers
{
    [TestFixture]
    public class ClaimsControllerTests
	{
        private AutoMocker _mocker;
        private ClaimsController _controller;

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMocker();
            _controller = _mocker.CreateInstance<ClaimsController>();
        }

        [Test]
        public async Task TestShouldReturnListOfClaims()
        {
          
            var response = new ClaimsResponseDto();
            var auth = "Admin001";
            _controller.TempAuth = auth;


            _mocker.GetMock<IClaimsService>()
                    .Setup(x => x.GetAllClaims())
                    .ReturnsAsync(new List<ClaimsResponseDto> { response });
            

            var result = await _controller.GetClaims();

            Assert.That(result.Result, Contains.Item(response));
        }

        [Test]
        public async Task TestShouldReturnSingleClaim()
        {
            var response = new ClaimsResponseDto();
           
            _mocker.GetMock<IClaimsService>()
                    .Setup(x => x.GetById("CLA001"))
                    .ReturnsAsync(response);


            var result = await _controller.GetClaimsById("CLA001");

            Assert.That(result.Result, Is.EqualTo(response));
        }

        [Test]
        public async Task TestShouldCreateClaim()
        {
            var claim = new ClaimsDto()
            {
                Amount = 100,
                NationalIDOfPolicyHolder="NGN022",
                ExpenseId = 1,
                DateOfExpense= new DateTime(2023,04,05)
            };
            
            var result = await _controller.CreateClaim(claim);

            _mocker.GetMock<IClaimsService>()
                    .Verify(x => x.CreateClaim(claim), Times.Once);

            Assert.That(result.IsSuccess, Is.True);
        }


        [Test]
        public async Task TestShouldUpdateClaim()
        {
            var claim = new ClaimsStatusUpdateDto()
            {
                ClaimsStatus = "Approved",
                Id = 1
            };
            var auth = "Admin001";
            _controller.TempAuth = auth;

            var result = await _controller.UpdateClaim(claim);

            _mocker.GetMock<IClaimsService>()
                    .Verify(x => x.UpdateClaim(claim.Id, claim.ClaimsStatus), Times.Once);

            Assert.That(result.IsSuccess, Is.True);
        }
    }
}

