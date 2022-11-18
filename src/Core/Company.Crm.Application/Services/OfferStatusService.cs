using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;

namespace Company.Crm.Application.Services;

public class OfferStatusService : IOfferStatusService
{
    private readonly IOfferStatusRepository _offerStatusRepository;

    public OfferStatusService(IOfferStatusRepository offerStatusRepository)
    {
        _offerStatusRepository = offerStatusRepository;
    }

    public bool Delete(OfferStatus entity)
    {
        return _offerStatusRepository.Delete(entity);
    }

    public bool DeleteById(int id)
    {
        return _offerStatusRepository.DeleteById(id);
    }

    public List<OfferStatus> GetAll()
    {
        return _offerStatusRepository.GetAll().ToList();
    }

    public OfferStatus? GetById(int id)
    {
        return _offerStatusRepository.GetById(id);
    }

    public bool Insert(OfferStatus entity)
    {
        return _offerStatusRepository.Insert(entity);
    }

    public bool Update(OfferStatus entity)
    {
        return _offerStatusRepository.Update(entity);
    }
}