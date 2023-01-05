using AutoMapper;
using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Entities.Lst;
using Company.Crm.Domain.Repositories;
using Company.Crm.Entityframework.Repositories;

namespace Company.Crm.Application.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IMapper _mapper;
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
    {
        _departmentRepository = departmentRepository;
        _mapper = mapper;
    }

    public List<Department> GetAll()
    {
        var entityList = _departmentRepository.GetAll().ToList();
        return entityList;
    }

    public Department? GetById(int id)
    {
        var entity = _departmentRepository.GetById(id);
        return entity;
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

    public List<Department> GetPaged(int page = 1)
    {
        var entityList = _departmentRepository.GetAll().OrderByDescending(c => c.Id);
        var pagedList = entityList.Skip((page - 1) * 10).Take(10).ToList();
        return pagedList;
    }

    public Department GetForEditById(int id)
    {
        var department = _departmentRepository.GetById(id);

        return department;
    }
}