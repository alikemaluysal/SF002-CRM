﻿using AutoMapper;
using Company.Crm.Application.Dtos.UserEmail;
using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Enums;
using Company.Crm.Domain.Repositories;

namespace Company.Crm.Application.Services;

public class UserEmailService : IUserEmailService
{
    private readonly IUserEmailRepository _userEmailRepository;
    private readonly IMapper _mapper;

    public UserEmailService(IUserEmailRepository userEmailRepository , IMapper mapper)
    {
        _userEmailRepository = userEmailRepository;
        _mapper = mapper;
    }

    public List<UserEmailDto> GetAll()
    {

        //return _userEmailRepository.GetAll().ToList();
        var entityList = _userEmailRepository.GetAll();
        var dtoList = _mapper.Map<List<UserEmailDto>>(entityList);
        return dtoList;
    }

    public UserEmailDto GetById(int id)
    {
        var entity = _userEmailRepository.GetById(id);
        var dto = _mapper.Map<UserEmailDto>(entity);
        return dto;
    }

    public bool Insert(UserEmail dto)
    {
        var userEmail = _mapper.Map<UserEmail>(dto);
        return _userEmailRepository.Update(userEmail);
    }

    public bool Update(UserEmail entity)
    {
        var userEmail = _mapper.Map<UserEmail>(entity);
        return _userEmailRepository.Update(userEmail);
    }

    public bool Delete(UserEmail entity)
    {
        var userEmail = _mapper.Map<UserEmail>(entity);
        return _userEmailRepository.Delete(userEmail);
    }

    public bool DeleteById(int id)
    {
        return _userEmailRepository.DeleteById(id);
    }

    public CreateOrUpdateUserEmailDto? GetForEditById(int id)
    {
        var entity = _userEmailRepository.GetById(id);
        var dto = _mapper.Map<CreateOrUpdateUserEmailDto>(entity);
        return dto;
      
    }

    public List<UserEmail> GetPaged(int page = 1)
    {
        var entityList = _userEmailRepository.GetAll()
            .OrderByDescending(c => c.Id);

        var pagedList = entityList.Skip((page - 1) * 10).Take(10).ToList();

        var dtoList = _mapper.Map<List<UserEmail>>(pagedList);

        return dtoList;
    }
}