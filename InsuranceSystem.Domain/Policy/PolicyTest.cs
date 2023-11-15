using NUnit.Framework;

namespace InsuranceSystem.Domain.Policy
{
    [TestFixture]
	public class PolicyTest
	{
		private PolicyHolder _policy;
		const int Id = 1;
		const string PolicyNumber = "NGN024";

		[SetUp]
		public void Setup()
		{
			_policy = new PolicyHolder();
		}

		[Test]
		public void TestGetAndSetIdValue()
		{
			_policy.Id = Id;

			Assert.That(_policy.Id, Is.EqualTo(Id));
		}

		[Test]
		public void TestGetAndSetPolicyNumber()
		{
			_policy.PolicyNumber = PolicyNumber;

			Assert.That(_policy.PolicyNumber, Is.EqualTo(PolicyNumber));
		}

	}
}

