using InsuranceSystem.Domain.Common;

namespace InsuranceSystem.Infrastructure.Interface
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
        where T : IEntity
    {
    }
}

