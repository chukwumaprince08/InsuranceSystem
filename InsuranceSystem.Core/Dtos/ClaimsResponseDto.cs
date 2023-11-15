using System;
namespace InsuranceSystem.Core.Dtos
{
	public class ClaimsResponseDto
	{
        public int Id { get; set; }

        public string ClaimsId { get; set; }

        public string NationalIDOfPolicyHolder { get; set; }

        public string Expenses { get; set; }

        public decimal Amount { get; set; }

        public DateTime DateOfExpense { get; set; }

        public string ClaimsStatus { get; set; }
    }
}

