using System.ComponentModel.DataAnnotations.Schema;
using InsuranceSystem.Domain.Common;
using InsuranceSystem.Domain.Expenses;

namespace InsuranceSystem.Domain.Claims
{
    public class Claim: BaseEntity
	{
		public string ClaimsId { get; set; }

		public string NationalIDOfPolicyHolder { get; set; }

		[ForeignKey("Expenses")]
		public int ExpenseId { get; set; }
		public Expense Expenses { get; set; }

		public decimal Amount { get; set; }

		public DateTime DateOfExpense { get; set; }

		public string ClaimsStatus { get; set; }
	}
}

