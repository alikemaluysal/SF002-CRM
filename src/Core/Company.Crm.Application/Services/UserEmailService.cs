using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;

namespace Company.Crm.Application.Services;

public class UserEmailService : IUserEmailService
{
    private readonly IUserEmailRepository _userEmailRepository;

    public UserEmailService(IUserEmailRepository userEmailRepository)
    {
        _userEmailRepository = userEmailRepository;
    }

    public List<UserEmail> GetAll()
    {
        return _userEmailRepository.GetAll().ToList();
    }

    public UserEmail? GetById(int id)
    {
        return _userEmailRepository.GetById(id);
    }

    public bool Insert(UserEmail entity)
    {
        return _userEmailRepository.Insert(entity);
    }

    public bool Update(UserEmail entity)
    {
        return _userEmailRepository.Update(entity);
    }

    public bool Delete(UserEmail entity)
    {
        return _userEmailRepository.Delete(entity);
    }

    public bool DeleteById(int id)
    {
        return _userEmailRepository.DeleteById(id);
    }
}