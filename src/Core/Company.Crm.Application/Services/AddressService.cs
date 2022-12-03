﻿using AutoMapper;
using Company.Crm.Application.Dtos.Address;
using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Enums;
using Company.Crm.Domain.Repositories;

namespace Company.Crm.Application.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;
    readonly IMapper _mapper;
    public AddressService(IAddressRepository addressRepository, IMapper mapper)
    {
        _addressRepository = addressRepository;
        _mapper = mapper;
    }

    public bool Delete(AddressDetailDto dto)
    {
        var address = _mapper.Map<Address>(dto);

        return _addressRepository.Delete(address);
    }
    public bool DeleteById(int id)
    {
        return _addressRepository.DeleteById(id);
    }
    public List<AddressDetailDto> GetAll()
    {
        var entityList = _addressRepository.GetAll();
        var dtoList = _mapper.Map<List<AddressDetailDto>>(entityList);
        return dtoList;
    }
    public AddressDetailDto? GetById(int id)
    {
        var entity = _addressRepository.GetById(id);
        var dto = _mapper.Map<AddressDetailDto>(entity);
        return dto;
    }

    public AddressCreateOrUpdateDto? GetForEditById(int id)
    {
        var entity = _addressRepository.GetById(id);
        //var dto = _mapper.Map<AddressCreateOrUpdateDto>(entity);
        var dto = new AddressCreateOrUpdateDto()
        {
            Id = entity.Id,
            AddressTypeEnumNumber = (int)entity.AddressType,
            Description = entity.Description,
            UserId = entity.UserId,
        };
        return dto;
    }
    public List<AddressDetailDto> GetPaged(int page = 1)
    {
        var entityList = _addressRepository.GetAll()
            .OrderByDescending(c => c.Id);

        var pagedList = entityList.Skip((page - 1) * 10).Take(10).ToList();
        var dtoList = _mapper.Map<List<AddressDetailDto>>(pagedList);
        return dtoList;
    }
    public bool Insert(AddressCreateOrUpdateDto dto)
    {
        Address address = new()
        {
            Description = dto.Description,
            UserId = dto.UserId,
            AddressType = (AddressTypeEnum)dto.AddressTypeEnumNumber,
        };
        //var address = _mapper.Map<Address>(dto);
        return _addressRepository.Insert(address);
    }
    public bool Update(AddressCreateOrUpdateDto dto)
    {
        Address address = _addressRepository.GetById(dto.Id);
        address.Description = dto.Description;
        address.UserId = dto.UserId;
        address.AddressType = (AddressTypeEnum)dto.AddressTypeEnumNumber;
        //var address = _mapper.Map<Address>(dto)
        return _addressRepository.Update(address);
    }
}

