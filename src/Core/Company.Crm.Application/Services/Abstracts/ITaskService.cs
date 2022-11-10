﻿using Task = Company.Crm.Domain.Entities.Task;

namespace Company.Crm.Application.Services.Abstracts;

public interface ITaskService
{
    public List<Task> GetAll();
    public Task? GetById(int id);
    public bool Insert(Task entity);
    public bool Update(Task entity);
    public bool Delete(Task entity);
    public bool DeleteById(int id);
}