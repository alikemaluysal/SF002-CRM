using Company.Crm.Application.Dtos;
using Company.Crm.Domain.Entities;

namespace Company.Crm.Application.Services.Abstracts;

public interface IUserService
{
    List<User> GetAll();
    User? GetById(int id);
    bool Insert(User entity);
    bool Update(User entity);
    bool Delete(User id);
    bool DeleteById(int id);
    bool Login(LoginDto dto);
}