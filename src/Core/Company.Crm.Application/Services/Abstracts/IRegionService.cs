using Company.Crm.Domain.Entities.Lst;

namespace Company.Crm.Application.Services.Abstracts;

public interface IRegionService
{
    List<Region> GetAll();
    Region? GetById(int id);
    bool Insert(Region entity);
    bool Update(Region entity);
    bool Delete(Region entity);
    bool DeleteById(int id);
    List<Region> GetPaged(int page = 1);
    Region GetForEditById(int id);
}