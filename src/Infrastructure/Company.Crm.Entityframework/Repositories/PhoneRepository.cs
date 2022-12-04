using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;
using Company.Framework.Repository;

namespace Company.Crm.Entityframework.Repositories;

public class PhoneRepository : BaseRepository<AppDbContext, Phone>, IPhoneRepository
{
    public PhoneRepository(AppDbContext ctx) : base(ctx)
    {
    }
}