using Company.Crm.Application.Dtos.UserEmail;
using Company.Crm.Domain.Entities;

namespace Company.Crm.Application.Services.Abstracts;

public interface IUserEmailService
{
    public List<UserEmailDto> GetAll();
    public UserEmailDto? GetById(int id);
    bool Insert(CreateOrUpdateUserEmailDto dto);
    bool Update(CreateOrUpdateUserEmailDto dto);
    bool Delete(CreateOrUpdateUserEmailDto dto);
    bool DeleteById(int id);
    CreateOrUpdateUserEmailDto? GetForEditById(int id);
    List<UserEmail> GetPaged(int page = 1);
}