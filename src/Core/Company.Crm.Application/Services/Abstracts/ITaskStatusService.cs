using Company.Crm.Domain.Entities.Lst;
using TaskStatus = Company.Crm.Domain.Entities.Lst.TaskStatus;

namespace Company.Crm.Application.Services.Abstracts;

public interface ITaskStatusService
{
    public List<TaskStatus> GetAll();
    public TaskStatus? GetById(int id);
    public bool Insert(TaskStatus entity);
    public bool Update(TaskStatus entity);
    public bool Delete(TaskStatus entity);
    public bool DeleteById(int id);
}
