using Company.Crm.Domain.Entities;

namespace Company.Crm.Application.Services.Abstracts;

public interface IUserEmailService
{
    public List<UserEmail> GetAll();
    public UserEmail? GetById(int id);
    public bool Insert(UserEmail entity);
    public bool Update(UserEmail entity);
    public bool Delete(UserEmail entity);
    public bool DeleteById(int id);
}