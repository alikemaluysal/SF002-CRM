using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;

namespace Company.Crm.Application.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;

    public AddressService(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public List<Address> GetAll()
    {
        return _addressRepository.GetAll();
    }

    public Address? GetById(int id)
    {
        return _addressRepository.GetById(id);
    }

    public bool Insert(Address entity)
    {
        return _addressRepository.Insert(entity);
    }

    public bool Update(Address entity)
    {
        return _addressRepository.Update(entity);
    }

    public bool Delete(Address entity)
    {
        return _addressRepository.Delete(entity);
    }

    public bool DeleteById(int id)
    {
        return _addressRepository.DeleteById(id);
    }
}