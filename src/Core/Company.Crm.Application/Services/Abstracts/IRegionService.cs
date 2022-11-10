﻿using Company.Crm.Domain.Entities;

namespace Company.Crm.Application.Services.Abstracts;

public interface IRegionService
{
    public List<Region> GetAll();
    public Region? GetById(int id);
    public bool Insert(Region entity);
    public bool Update(Region entity);
    public bool Delete(Region entity);
    public bool DeleteById(int id);
}