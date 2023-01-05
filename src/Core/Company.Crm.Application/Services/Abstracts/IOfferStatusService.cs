using Company.Crm.Domain.Entities.Lst;

namespace Company.Crm.Application.Services.Abstracts;

public interface IOfferStatusService
{
    List<OfferStatus> GetAll();
    OfferStatus? GetById(int id);
    bool Insert(OfferStatus entity);
    bool Update(OfferStatus entity);
    bool Delete(OfferStatus entity);
    bool DeleteById(int id);
    List<OfferStatus> GetPaged(int page = 1);
}