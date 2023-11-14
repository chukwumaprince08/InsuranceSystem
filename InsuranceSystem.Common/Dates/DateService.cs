using System;
namespace InsuranceSystem.Common.Dates
{
	public class DateService : IDateService
	{
		public DateTime GetDate() => DateTime.Now;
	}
}

