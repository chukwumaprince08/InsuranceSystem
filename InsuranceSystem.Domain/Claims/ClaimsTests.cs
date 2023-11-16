using NUnit.Framework;

namespace InsuranceSystem.Domain.Claims
{
    [TestFixture]
	public class ClaimsTests
	{
        private Claim _claim;
        const int Id = 1;
        const string ClaimsId = "CL0223";
        const string ClaimsStatus = "Submitted";

        [SetUp]
        public void Setup()
        {
            _claim = new Claim();
        }

        [Test]
        public void TestGetAndSetIdValue()
        {
            _claim.Id = Id;

            Assert.That(_claim.Id, Is.EqualTo(Id));
        }

        [Test]
        public void TestGetAndSetClaimsId()
        {
            _claim.ClaimsId = ClaimsId;

            Assert.That(_claim.ClaimsId, Is.EqualTo(ClaimsId));
        }

        [Test]
        public void TestGetAndSetClaimsStatus()
        {
            _claim.ClaimsStatus = ClaimsStatus;

            Assert.That(_claim.ClaimsStatus, Is.EqualTo(ClaimsStatus));
        }
    }
}

