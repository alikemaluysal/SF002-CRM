using TaskStatus = Company.Crm.Domain.Entities.Lst.TaskStatus;

namespace Company.Crm.Application.Services.Abstracts;

public interface ITaskStatusService
{
    List<TaskStatus> GetAll();
    TaskStatus? GetById(int id);
    bool Insert(TaskStatus entity);
    bool Update(TaskStatus entity);
    bool Delete(TaskStatus entity);
    bool DeleteById(int id);
    List<TaskStatus> GetPaged(int page = 1);
    TaskStatus? GetForEditById(int id);
}