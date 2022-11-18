using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;

namespace Company.Crm.Application.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }


    public List<Department> GetAll()
    {
        return _departmentRepository.GetAll().ToList();
    }

    public Department? GetById(int id)
    {
        return _departmentRepository.GetById(id);
    }

    public bool Insert(Department entity)
    {
        return _departmentRepository.Insert(entity);
    }

    public bool Update(Department entity)
    {
        return _departmentRepository.Update(entity);
    }

    public bool Delete(Department entity)
    {
        return _departmentRepository.Delete(entity);
    }

    public bool DeleteById(int id)
    {
        return _departmentRepository.DeleteById(id);
    }
}