using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;

namespace Company.Crm.Application.Services;

public class PersonEmailService : IPersonEmailService
{
    private readonly IEmailRepository _emailRepository;

    public PersonEmailService(IEmailRepository emailRepository)
    {
        _emailRepository = emailRepository;
    }

    public List<Email> GetAll()
    {
        return _emailRepository.GetAll().ToList();
    }

    public Email? GetById(int id)
    {
        return _emailRepository.GetById(id);
    }

    public bool Insert(Email entity)
    {
        return _emailRepository.Insert(entity);
    }

    public bool Update(Email entity)
    {
        return _emailRepository.Update(entity);
    }

    public bool Delete(Email entity)
    {
        return _emailRepository.Delete(entity);
    }

    public bool DeleteById(int id)
    {
        return _emailRepository.DeleteById(id);
    }
}