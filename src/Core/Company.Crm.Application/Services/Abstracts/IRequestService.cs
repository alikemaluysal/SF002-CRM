using Company.Crm.Application.Dtos;
using Company.Crm.Application.Dtos.Notification;
using Company.Crm.Application.Dtos.Request;

namespace Company.Crm.Application.Services.Abstracts;

public interface IRequestService
{
    List<RequestDto> GetAll();
    RequestCreateOrUpdateDto? GetForEditById(int id);
    RequestDto? GetById(int id);
    bool Insert(RequestCreateOrUpdateDto entity);
    bool Update(RequestCreateOrUpdateDto entity);
    bool Delete(RequestDto entity);
    bool DeleteById(int id);
    List<RequestDto> GetPaged(int page = 1);
}