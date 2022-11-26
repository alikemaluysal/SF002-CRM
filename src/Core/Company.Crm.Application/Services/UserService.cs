using Company.Crm.Application.Dtos;
using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;

namespace Company.Crm.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<User> GetAll()
    {
        return _userRepository.GetAll().ToList();
    }

    public User? GetById(int id)
    {
        return _userRepository.GetById(id);
    }

    public bool Insert(User entity)
    {
        return _userRepository.Insert(entity);
    }

    public bool Update(User entity)
    {
        return _userRepository.Update(entity);
    }

    public bool Delete(User entity)
    {
        return _userRepository.Delete(entity);
    }

    public bool DeleteById(int id)
    {
        return _userRepository.DeleteById(id);
    }

    public User Login(LoginDto dto)
    {
        var user = _userRepository.GetAll()
            .Where(c => (c.Username == dto.EmailAddressOrUsername || c.Email == dto.EmailAddressOrUsername) && c.Password == dto.Password)
            .FirstOrDefault();

        return user;
    }

    public User Register(RegisterDto dto)
    {
        var user = new User
        {
            Name = dto.Name,
            Surname = dto.Surname,
            Username = dto.Name.ToLower() + dto.Surname.ToLower(),
            Email = dto.EmailAddress,
            Password = dto.Password
        };

        var isCreated = _userRepository.Insert(user);
        if (isCreated)
            return user;

        return null;
    }
}