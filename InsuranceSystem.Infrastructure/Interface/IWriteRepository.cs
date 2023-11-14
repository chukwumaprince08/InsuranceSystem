using System;
namespace InsuranceSystem.Infrastructure.Interface
{
    public interface IWriteRepository<in T>
    {
        void Add(T item);
        void Remove(T item);
        void Save();
    }
}

