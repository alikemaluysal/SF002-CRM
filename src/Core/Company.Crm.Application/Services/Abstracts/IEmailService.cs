using Company.Crm.Domain.Entities;

namespace Company.Crm.Application.Services.Abstracts;

public interface IPersonEmailService
{
    public List<Email> GetAll();
    public Email? GetById(int id);
    public bool Insert(Email entity);
    public bool Update(Email entity);
    public bool Delete(Email entity);
    public bool DeleteById(int id);
}