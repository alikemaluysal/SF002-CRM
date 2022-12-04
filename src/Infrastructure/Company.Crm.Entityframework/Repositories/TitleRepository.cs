using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;
using Company.Framework.Repository;

namespace Company.Crm.Entityframework.Repositories;

public class TitleRepository : BaseRepository<AppDbContext, Title>, ITitleRepository
{
    public TitleRepository(AppDbContext ctx) : base(ctx)
    {
    }
}