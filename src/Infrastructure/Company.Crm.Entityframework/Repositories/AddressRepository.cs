using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;
using Company.Framework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Entityframework.Repositories
{
    public class AddressRepository : BaseRepository<AppDbContext, Address>, IAddressRepository
    {
        private readonly AppDbContext _ctx;
        public AddressRepository(AppDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
