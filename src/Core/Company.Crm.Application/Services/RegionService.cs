﻿using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities.Lst;
using Company.Crm.Domain.Repositories;

namespace Company.Crm.Application.Services;

public class RegionService : IRegionService
{
    private readonly IRegionRepository _regionRepository;

    public RegionService(IRegionRepository regionRepository)
    {
        _regionRepository = regionRepository;
    }

    public List<Region> GetAll()
    {
        return _regionRepository.GetAll().ToList();
    }

    public Region? GetById(int id)
    {
        return _regionRepository.GetById(id);
    }

    public bool Insert(Region entity)
    {
        return _regionRepository.Insert(entity);
    }

    public bool Update(Region entity)
    {
        return _regionRepository.Update(entity);
    }

    public bool Delete(Region entity)
    {
        return _regionRepository.Delete(entity);
    }

    public bool DeleteById(int id)
    {
        return _regionRepository.DeleteById(id);
    }

    public List<Region> GetPaged(int page = 1)
    {
        var entityList = _regionRepository.GetAll().OrderByDescending(c => c.Id);

        var pagedList = entityList.Skip((page - 1) * 10).Take(10).ToList();

        return pagedList;
    }


    public Region GetForEditById(int id)
    {
        var region = _regionRepository.GetById(id);

        return region;
    }
}