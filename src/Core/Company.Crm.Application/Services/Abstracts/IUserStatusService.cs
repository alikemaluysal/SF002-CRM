﻿using Company.Crm.Domain.Entities;

namespace Company.Crm.Application.Services.Abstracts;

public interface IUserStatusService
{
    public List<UserStatus> GetAll();
    public UserStatus? GetById(int id);
    public bool Insert(UserStatus entity);
    public bool Update(UserStatus entity);
    public bool Delete(UserStatus entity);
    public bool DeleteById(int id);
}