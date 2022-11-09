using Company.Crm.Application.Dtos;

namespace Company.Crm.Application.Services.Abstracts;

public interface IOfferService
{
    public List<OfferDto> GetAll();
    public OfferDto? GetById(int id);
    public bool Insert(OfferDto entity);
    public bool Update(OfferDto entity);
    public bool Delete(OfferDto entity);
    public bool DeleteById(int id);
}