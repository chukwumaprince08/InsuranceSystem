using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceSystem.Domain.Common
{
	public abstract class BaseEntity: IEntity
	{
		public DateTime DateCreated { get; set; }

		public DateTime DateModified { get; set; }

        public int Id { get; set; }
    }
}

