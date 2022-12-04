using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;

namespace Company.Crm.Application.Services;

public class UserEmailService : IUserEmailService
{
    private readonly IEmailRepository _emailRepository;

    public UserEmailService(IEmailRepository emailRepository)
    {
        _emailRepository = emailRepository;
    }

    public List<UserEmail> GetAll()
    {
        return _emailRepository.GetAll().ToList();
    }

    public UserEmail? GetById(int id)
    {
        return _emailRepository.GetById(id);
    }

    public bool Insert(UserEmail entity)
    {
        return _emailRepository.Insert(entity);
    }

    public bool Update(UserEmail entity)
    {
        return _emailRepository.Update(entity);
    }

    public bool Delete(UserEmail entity)
    {
        return _emailRepository.Delete(entity);
    }

    public bool DeleteById(int id)
    {
        return _emailRepository.DeleteById(id);
    }
}