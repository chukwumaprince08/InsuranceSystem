using System;
namespace InsuranceSystem.Core.Interface
{
	public interface IRepositoryManager
	{
        IPolicyHolderRepository PolicyHolder { get; }
        Task<int> SaveChangesAsync();
    }
}

