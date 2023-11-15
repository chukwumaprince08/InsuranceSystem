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
    }
}

