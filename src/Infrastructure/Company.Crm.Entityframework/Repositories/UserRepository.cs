using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;
using Company.Framework.Repository;

namespace Company.Crm.Entityframework.Repositories;

public class UserRepository : BaseRepository<AppDbContext, User>, IUserRepository
{
    private readonly AppDbContext _ctx;

    public UserRepository(AppDbContext context) : base(context)
    {
        _ctx = context;
    }
}