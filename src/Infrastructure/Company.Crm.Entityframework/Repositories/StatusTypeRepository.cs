using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;
using Company.Framework.Repository;

namespace Company.Crm.Entityframework.Repositories;

public class StatusTypeRepository : BaseRepository<AppDbContext, StatusType>, IStatusTypeRepository
{
    private readonly AppDbContext _ctx;

    public StatusTypeRepository(AppDbContext ctx) : base(ctx)
    {
        _ctx = ctx;
    }
}