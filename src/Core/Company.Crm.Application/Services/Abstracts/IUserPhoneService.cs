using Company.Crm.Domain.Entities;

namespace Company.Crm.Application.Services.Abstracts;

public interface IUserPhoneService
{
    public List<UserPhone> GetAll();
    public UserPhone? GetById(int id);
    public bool Insert(UserPhone entity);
    public bool Update(UserPhone entity);
    public bool Delete(UserPhone entity);
    public bool DeleteById(int id);
}