﻿using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;
using Company.Framework.Repository;

namespace Company.Crm.Entityframework.Repositories;

public class OfferStatusRepository : BaseRepository<AppDbContext, OfferStatus>, IOfferStatusRepository
{
    private readonly AppDbContext _ctx;

    public OfferStatusRepository(AppDbContext ctx) : base(ctx)
    {
        _ctx = ctx;
    }
}