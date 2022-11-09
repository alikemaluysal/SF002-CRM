using Company.Crm.Domain.Entities;

namespace Company.Crm.Application.Services.Abstracts;

public interface IAddressService
{
    public List<Address> GetAll();
    public Address? GetById(int id);
    public bool Insert(Address entity);
    public bool Update(Address entity);
    public bool Delete(Address entity);
    public bool DeleteById(int id);
}