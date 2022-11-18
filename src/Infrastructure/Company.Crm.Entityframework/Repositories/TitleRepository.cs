using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;
using Company.Framework.Repository;

namespace Company.Crm.Entityframework.Repositories;

public class TitleRepository : BaseRepository<AppDbContext, Title>, ITitleRepository
{
    private readonly AppDbContext _ctx;

    public TitleRepository(AppDbContext context) : base(context)
    {
        _ctx = context;
    }
}