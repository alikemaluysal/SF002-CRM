using Company.Crm.Application.Dtos;

namespace Company.Crm.Application.Services.Abstracts;

public interface IRequestService
{
    List<RequestDto> GetAll();
    RequestDto? GetById(int id);
    bool Insert(RequestDto entity);
    bool Update(RequestDto entity);
    bool Delete(RequestDto entity);
    bool DeleteById(int id);
}