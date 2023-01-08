using Company.Crm.Application.Dtos;

namespace Company.Crm.Application.Services.Abstracts;

public interface IOfferService
{
    List<OfferDto> GetAll();
    OfferDto? GetById(int id);
    bool Insert(OfferDto entity);
    bool Update(OfferDto entity);
    bool Delete(OfferDto entity);
    bool DeleteById(int id);
}