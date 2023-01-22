using AutoMapper;
using Company.Crm.Application.Dtos.Task;
using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Repositories;
using Task = Company.Crm.Domain.Entities.Task;

namespace Company.Crm.Application.Services;

// Concrete-Abstract
public class TaskService : ITaskService
{
    private readonly IMapper _mapper;
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public List<TaskDto> GetAll()
    {
        var entityList = _taskRepository.GetAll();

        var dtoList = _mapper.Map<List<TaskDto>>(entityList);

        return dtoList;
    }

    public List<TaskDto> GetPaged(int page = 1)
    {
        var entityList = _taskRepository.GetAll()
            .OrderByDescending(c => c.Id);

        var pagedList = entityList.Skip((page - 1) * 10).Take(10).ToList();

        var dtoList = _mapper.Map<List<TaskDto>>(pagedList);

        return dtoList;
    }

    public TaskDto? GetById(int id)
    {
        var entity = _taskRepository.GetById(id);
        var dto = _mapper.Map<TaskDto>(entity);
        return dto;
    }

    public CreateOrUpdateTaskDto? GetForEditById(int id)
    {
        var entity = _taskRepository.GetById(id);
        var dto = _mapper.Map<CreateOrUpdateTaskDto>(entity);
        return dto;
    }

    public bool Insert(CreateOrUpdateTaskDto dto)
    {
        var task = _mapper.Map<Task>(dto);

        return _taskRepository.Insert(task);
    }

    public bool Update(CreateOrUpdateTaskDto dto)
    {
        var task = _mapper.Map<Task>(dto);

        return _taskRepository.Update(task);
    }

    public bool Delete(TaskDto dto)
    {
        var task = _mapper.Map<Task>(dto);

        return _taskRepository.Delete(task);
    }

    public bool DeleteById(int id)
    {
        return _taskRepository.DeleteById(id);
    }
}