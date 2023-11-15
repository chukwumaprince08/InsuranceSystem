using InsuranceSystem.Domain.Common;

namespace InsuranceSystem.Domain.Expenses
{
    public class Expense: BaseEntity
	{
		public string ExpenseType { get; set; }	// Procedure or Prescription
		public string ExpenseDescription { get; set; }	// Description (name of procedure or name of medication)
	}
}

