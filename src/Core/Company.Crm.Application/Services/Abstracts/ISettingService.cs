using Company.Crm.Domain.Entities;

namespace Company.Crm.Application.Services.Abstracts;

public interface ISettingService
{
    public List<Setting> GetAll();

    public Setting? GetById(int id);

    public bool Insert(Setting entity);

    public bool Update(Setting entity);

    public bool Delete(Setting entity);

    public bool DeleteById(int id);

    List<Setting> GetPaged(int page = 1);
}