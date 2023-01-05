﻿using Company.Crm.Domain.Entities.Lst;

namespace Company.Crm.Application.Services.Abstracts;

public interface ITitleService
{
    public List<Title> GetAll();

    public Title? GetById(int id);

    public bool Insert(Title entity);

    public bool Update(Title entity);

    public bool Delete(Title entity);

    public bool DeleteById(int id);

    List<Title> GetPaged(int page = 1);

}