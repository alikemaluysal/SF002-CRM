using Company.Crm.Application.Dtos;
using Company.Crm.Application.Dtos.Task;
using Task = Company.Crm.Domain.Entities.Task;

namespace Company.Crm.Application.Services.Abstracts;

public interface ITaskService
{
    List<TaskDto> GetAll();
    TaskDto? GetById(int id);
    CreateOrUpdateTaskDto? GetForEditById(int id);
    bool Insert(CreateOrUpdateTaskDto dto);
    bool Update(CreateOrUpdateTaskDto dto);
    bool Delete(TaskDto dto);
    bool DeleteById(int id);
    List<TaskDto> GetPaged(int page = 1);
}