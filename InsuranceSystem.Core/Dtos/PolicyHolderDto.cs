using System;
namespace InsuranceSystem.Core.Dtos
{
	public class PolicyHolderDto
	{
        public string NationalIDNumber { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PolicyNumber { get; set; }
    }
}

