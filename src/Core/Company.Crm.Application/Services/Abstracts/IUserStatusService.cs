using Company.Crm.Domain.Entities.Lst;

namespace Company.Crm.Application.Services.Abstracts;

public interface IUserStatusService
{
    List<UserStatus> GetAll();
    UserStatus? GetById(int id);
    bool Insert(UserStatus entity);
    bool Update(UserStatus entity);
    bool Delete(UserStatus entity);
    bool DeleteById(int id);
}