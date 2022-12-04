using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;
using Company.Framework.Repository;

namespace Company.Crm.Entityframework.Repositories;

public class AddressRepository : BaseRepository<AppDbContext, UserAddress>, IAddressRepository
{
    public AddressRepository(AppDbContext ctx) : base(ctx)
    {
    }
}