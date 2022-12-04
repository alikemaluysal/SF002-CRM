using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;

namespace Company.Crm.Application.Services;

public class UserPhoneService : IUserPhoneService
{
    private readonly IPhoneRepository _phoneRepository;

    public UserPhoneService(IPhoneRepository phoneRepository)
    {
        _phoneRepository = phoneRepository;
    }

    public List<UserPhone> GetAll()
    {
        return _phoneRepository.GetAll().ToList();
    }

    public UserPhone? GetById(int id)
    {
        return _phoneRepository.GetById(id);
    }

    public bool Insert(UserPhone entity)
    {
        return _phoneRepository.Insert(entity);
    }

    public bool Update(UserPhone entity)
    {
        return _phoneRepository.Update(entity);
    }

    public bool Delete(UserPhone entity)
    {
        return _phoneRepository.Delete(entity);
    }

    public bool DeleteById(int id)
    {
        return _phoneRepository.DeleteById(id);
    }
}