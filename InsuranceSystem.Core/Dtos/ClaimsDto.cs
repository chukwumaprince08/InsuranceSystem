namespace InsuranceSystem.Core.Dtos
{
    public class ClaimsDto
	{
        public string ClaimsId { get; set; }

        public string NationalIDOfPolicyHolder { get; set; }
        
        public int ExpenseId { get; set; }

        public decimal Amount { get; set; }

        public DateTime DateOfExpense { get; set; }

        public string ClaimsStatus { get; set; }
    }
}

