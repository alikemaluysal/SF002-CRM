using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities.Lst;
using Company.Crm.Domain.Repositories;
using Company.Crm.Entityframework.Repositories;

namespace Company.Crm.Application.Services;


public class RequestStatusService : IRequestStatusService
{
    private readonly IRequestStatusRepository _requestStatusesRepository;

    public RequestStatusService(IRequestStatusRepository requestStatusesRepository)
    {
        _requestStatusesRepository = requestStatusesRepository;
    }

    public bool Delete(RequestStatus entity)
    {
        return _requestStatusesRepository.Delete(entity);
    }

    public bool DeleteById(int id)
    {
        return _requestStatusesRepository.DeleteById(id);
    }

    public List<RequestStatus> GetAll()
    {
        return _requestStatusesRepository.GetAll().ToList();
    }

    public RequestStatus? GetById(int id)
    {
        return _requestStatusesRepository.GetById(id);
    }

    public bool Insert(RequestStatus entity)
    {
        return _requestStatusesRepository.Insert(entity);
    }

    public bool Update(RequestStatus entity)
    {
        return _requestStatusesRepository.Update(entity);
    }

    public List<RequestStatus> GetPaged(int page = 1)
    {
        var entityList = _requestStatusesRepository.GetAll().OrderByDescending(c => c.Id);
        var pagedList = entityList.Skip((page - 1) * 10).Take(10).ToList();
        return pagedList;
    }

    public RequestStatus GetForEditById(int id)
    {
        var requeststatus = _requestStatusesRepository.GetById(id);

        return requeststatus;
    }

}
