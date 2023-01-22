using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Repositories;
using TaskStatus = Company.Crm.Domain.Entities.Lst.TaskStatus;

namespace Company.Crm.Application.Services;

public class TaskStatusService : ITaskStatusService
{
    private readonly ITaskStatusRepository _taskStatusRepository;

    public TaskStatusService(ITaskStatusRepository taskStatusRepository)
    {
        _taskStatusRepository = taskStatusRepository;
    }

    public List<TaskStatus> GetAll()
    {
        return _taskStatusRepository.GetAll().ToList();
    }

    public List<TaskStatus> GetPaged(int page = 1)
    {
        var entityList = _taskStatusRepository.GetAll().OrderByDescending(c => c.Id);

        var pagedList = entityList.Skip((page - 1) * 10).Take(10).ToList();
        return pagedList;
    }

    public TaskStatus? GetForEditById(int id)
    {
        var taskStatus = _taskStatusRepository.GetById(id);
        return taskStatus;
    }
    
    public TaskStatus? GetById(int id)
    {
        return _taskStatusRepository.GetById(id);
    }

    public bool Insert(TaskStatus entity)
    {
        return _taskStatusRepository.Insert(entity);
    }

    public bool Update(TaskStatus entity)
    {
        return _taskStatusRepository.Update(entity);
    }

    public bool Delete(TaskStatus entity)
    {
        return _taskStatusRepository.Delete(entity);
    }

    public bool DeleteById(int id)
    {
        return _taskStatusRepository.DeleteById(id);
    }
}