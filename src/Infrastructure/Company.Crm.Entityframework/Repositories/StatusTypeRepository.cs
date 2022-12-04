using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;
using Company.Framework.Repository;

namespace Company.Crm.Entityframework.Repositories;

public class StatusTypeRepository : BaseRepository<AppDbContext, StatusType>, IStatusTypeRepository
{
    public StatusTypeRepository(AppDbContext ctx) : base(ctx)
    {
    }
}