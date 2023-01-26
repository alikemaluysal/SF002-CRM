using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Repositories;
using Company.Framework.Dtos;
using TaskStatus = Company.Crm.Domain.Entities.Lst.TaskStatus;

namespace Company.Crm.Application.Services;

public class TaskStatusService : ITaskStatusService
{
	private readonly ITaskStatusRepository _taskStatusRepository;

	public TaskStatusService(ITaskStatusRepository taskStatusRepository)
	{
		_taskStatusRepository = taskStatusRepository;
	}

	public ServiceResponse<List<TaskStatus>> GetAll()
	{
		var data = _taskStatusRepository.GetAll().ToList();
		return new(data);
	}

	public ServiceResponse<TaskStatus?> GetById(int id)
	{
		var data = _taskStatusRepository.GetById(id);
		if (data == null)
			return new ServiceResponse<TaskStatus?>("Not Found!");
		return new(data);
	}

	public ServiceResponse<TaskStatus> GetForEditById(int id)
	{
		var data = _taskStatusRepository.GetById(id);
		return new(data);
	}

	public ServicePaginationResponse<List<TaskStatus>> GetPaged(PaginationRequest request)
	{
		var query = _taskStatusRepository.GetAll();
		var totalCount = query.Count();
		var data = query.Skip(request.Skip).Take(request.PerPage).ToList();
		return new ServicePaginationResponse<List<TaskStatus>>(data, totalCount, request);
	}
  
	public ServiceResponse<bool> Insert(TaskStatus entity)
	{
		return new(_taskStatusRepository.Insert(entity));
	}

	public ServiceResponse<bool> Update(TaskStatus entity)
	{
		return new(_taskStatusRepository.Update(entity));
	}

	public ServiceResponse<bool> Delete(TaskStatus entity)
	{
		return new ServiceResponse<bool>(_taskStatusRepository.Delete(entity));
	}

	public ServiceResponse<bool> DeleteById(int id)
	{
		return new ServiceResponse<bool>(_taskStatusRepository.DeleteById(id));
	}
}