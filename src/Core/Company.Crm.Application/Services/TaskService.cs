using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Repositories;
using Task = Company.Crm.Domain.Entities.Task;

namespace Company.Crm.Application.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public List<Task> GetAll()
    {
        return _taskRepository.GetAll();
    }

    public Task? GetById(int id)
    {
        return _taskRepository.GetById(id);
    }

    public bool Insert(Task entity)
    {
        return _taskRepository.Insert(entity);
    }

    public bool Update(Task entity)
    {
        return _taskRepository.Update(entity);
    }

    public bool Delete(Task entity)
    {
        return _taskRepository.Delete(entity);
    }

    public bool DeleteById(int id)
    {
        return _taskRepository.DeleteById(id);
    }
}