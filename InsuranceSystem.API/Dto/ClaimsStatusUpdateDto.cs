using System.ComponentModel.DataAnnotations;

namespace InsuranceSystem.API.Dto
{
    public class ClaimsStatusUpdateDto
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Claims Status is required")]
		public string ClaimsStatus { get; set; }
    }
}

