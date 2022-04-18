using VegaIT.Timesheet.Core.Contracts;

namespace VegaIT.Timesheet.Core.Repositories
{
    public interface IRepository<TDomainEntity> where TDomainEntity : IAggregateRoot
    {
    }
}