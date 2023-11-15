using InsuranceSystem.API.Controllers;
using InsuranceSystem.API.Dto;
using InsuranceSystem.Application.Services;
using InsuranceSystem.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;

namespace InsuranceSystem.API.Tests;

public class PolicyControllerTests
{
    private Mock<IPolicyService> _policyService;
    private PolicyHolderDto _policy;
    private ResponseDto _response;
    private PoliciesController _controller;

    public PolicyControllerTests()
    {
        _policyService = new Mock<IPolicyService>();
        _controller = new PoliciesController(_policyService.Object);
        _policy = new PolicyHolderDto();
        _response = new ResponseDto();
        _policyService.Setup(x => x.CreatePolicy(_policy)).ReturnsAsync(_policy);
    }

    [Theory]
    [InlineData(1, true, typeof(OkObjectResult))]
    [InlineData(0, false, typeof(BadRequestObjectResult))]
    public async Task Should_Call_Create_Policy_Method_At_Most_Once_When_Model_Is_Valid(int expectedMethodCalls, bool isModelValid, Type expectedActionResulttype)
    {
        // Arrange
        if (!isModelValid)
            _controller.ModelState.AddModelError("key", "ErrorMessage");

        // Act
        var result = await _controller.CreatePolicy(_policy);

        // Assert
        result.ShouldBeOfType(expectedActionResulttype);
        _policyService.Verify(x => x.CreatePolicy(_policy), Times.Exactly(expectedMethodCalls));
    }

    [Theory]
    [InlineData(0, typeof(IEnumerable<PolicyHolderDto>))]
    public async Task Should_Return_List_Of_Policies(int expectedNoOfCalls, Type expectedResultType)
    {
        // act
        var result = await _controller.GetPolicies();

        // assert
        result.ShouldBe(expectedResultType);
        _policyService.Verify(x => x.GetAllPolicies(), Times.Exactly(expectedNoOfCalls));
        
    }
}
