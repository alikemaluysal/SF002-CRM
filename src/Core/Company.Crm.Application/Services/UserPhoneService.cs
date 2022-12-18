using AutoMapper;
using Company.Crm.Application.Dtos;
using Company.Crm.Application.Dtos.UserPhone;
using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;
using Company.Crm.Entityframework.Repositories;

namespace Company.Crm.Application.Services;

public class UserPhoneService : IUserPhoneService
{
    private readonly IPhoneRepository _phoneRepository;
    private readonly IMapper _mapper;


    public UserPhoneService(IPhoneRepository phoneRepository, IMapper mapper)
    {
        _mapper = mapper;
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

    public bool Insert(CreateOrUpdateUserPhoneDto dto)
    {
        var userPhone = _mapper.Map<UserPhone>(dto);
        return _phoneRepository.Insert(userPhone);
    }

    public bool Update(CreateOrUpdateUserPhoneDto dto)
    {
        var userPhone = _mapper.Map<UserPhone>(dto);
        return _phoneRepository.Update(userPhone);
    }

    public bool Delete(UserPhoneDto dto)
    {
        var userPhone = _mapper.Map<UserPhone>(dto);
        return _phoneRepository.Delete(userPhone);
    }

    public bool DeleteById(int id)
    {
        return _phoneRepository.DeleteById(id);
    }

    public List<UserPhoneDto> GetPaged(int page = 1)
    {
        var entityList = _phoneRepository.GetAll()
            .OrderByDescending(c => c.Id);

        var pagedList = entityList.Skip((page - 1) * 10).Take(10).ToList();

        var dtoList = _mapper.Map<List<UserPhoneDto>>(pagedList);

        return dtoList;
    }

    public CreateOrUpdateUserPhoneDto? GetForEditById(int id)
    {
        var entity = _phoneRepository.GetById(id);
        var dto = _mapper.Map<CreateOrUpdateUserPhoneDto>(entity);
        return dto;
    }

}