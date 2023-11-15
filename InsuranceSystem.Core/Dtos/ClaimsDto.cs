using System.ComponentModel.DataAnnotations;

namespace InsuranceSystem.Core.Dtos
{
    public class ClaimsDto
	{
        [Required(ErrorMessage = "National Id is required")]
        [MaxLength(30, ErrorMessage = "Maximum length exceeded")]
        [MinLength(3, ErrorMessage = "Invalid ID number")]
        public string NationalIDOfPolicyHolder { get; set; }
        
        public int ExpenseId { get; set; }

        public decimal Amount { get; set; }

        public DateTime DateOfExpense { get; set; }
    }
}

