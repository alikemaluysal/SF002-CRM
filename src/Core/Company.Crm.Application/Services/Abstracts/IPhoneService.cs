using Company.Crm.Domain.Entities;

namespace Company.Crm.Application.Services.Abstracts;

public interface IPhoneService
{
    public List<Phone> GetAll();
    public Phone? GetById(int id);
    public bool Insert(Phone entity);
    public bool Update(Phone entity);
    public bool Delete(Phone entity);
    public bool DeleteById(int id);
}