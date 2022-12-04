using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;
using Company.Framework.Repository;

namespace Company.Crm.Entityframework.Repositories;

public class EmailRepository : BaseRepository<AppDbContext, Email>, IEmailRepository
{
    public EmailRepository(AppDbContext ctx) : base(ctx)
    {
    }
}