using NUnit.Framework;

namespace InsuranceSystem.Domain.Expenses
{
    [TestFixture]
	public class ExpenseTests
	{
        private Expense _expense;
        const int Id = 1;
        const string ExpenseType = "Procedure";

        [SetUp]
        public void Setup()
        {
            _expense = new Expense();
        }

        [Test]
        public void TestGetAndSetIdValue()
        {
            _expense.Id = Id;

            Assert.That(_expense.Id, Is.EqualTo(Id));
        }

        [Test]
        public void TestGetAndSetExpenseType()
        {
            _expense.ExpenseType = ExpenseType;

            Assert.That(_expense.ExpenseType, Is.EqualTo(ExpenseType));
        }
    }
}

