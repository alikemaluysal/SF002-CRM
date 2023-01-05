using Company.Crm.Domain.Entities.Lst;

namespace Company.Crm.Application.Services.Abstracts;

public interface IDepartmentService
{
    List<Department> GetAll();
    Department? GetById(int id);
    bool Insert(Department entity);
    bool Update(Department entity);
    bool Delete(Department entity);
    bool DeleteById(int id);
    List<Department> GetPaged(int page = 1);
    Department GetForEditById(int id);
}
