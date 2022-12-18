using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities.Lst;
using Company.Crm.Domain.Repositories;
using Company.Crm.Entityframework.Repositories;
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
