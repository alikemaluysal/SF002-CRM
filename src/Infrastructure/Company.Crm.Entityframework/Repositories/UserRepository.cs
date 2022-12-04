using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;
using Company.Framework.Repository;

namespace Company.Crm.Entityframework.Repositories;

public class UserRepository : BaseRepository<AppDbContext, User>, IUserRepository
{
    public UserRepository(AppDbContext ctx) : base(ctx)
    {
    }
}