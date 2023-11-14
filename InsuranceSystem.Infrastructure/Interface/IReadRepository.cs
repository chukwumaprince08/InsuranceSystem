using System;
namespace InsuranceSystem.Infrastructure.Interface
{
    public interface IReadRepository<out T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}

