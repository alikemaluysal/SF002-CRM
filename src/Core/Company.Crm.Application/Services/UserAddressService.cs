using AutoMapper;
using Company.Crm.Application.Dtos.Address;
using Company.Crm.Application.Dtos.UserAddress;
using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;
using Company.Framework.Dtos;

namespace Company.Crm.Application.Services;

public class UserAddressService : IUserAddressService
{
    private readonly IMapper _mapper;
    private readonly IUserAddressRepository _userAddressRepository;

    public UserAddressService(IUserAddressRepository userAddressRepository, IMapper mapper)
    {
        _userAddressRepository = userAddressRepository;
        _mapper = mapper;
    }

    public ServiceResponse<List<AddressDetailDto>> GetAll()
    {
        var entityList = _userAddressRepository.GetAll();
        var dtoList = _mapper.Map<List<AddressDetailDto>>(entityList);
        return new(dtoList);
    }

    public ServicePaginationResponse<List<AddressDetailDto>> GetPaged(PaginationRequest request)
    {
        var query = _userAddressRepository.GetAll().
            OrderByDescending(x => x.Id);
        var totalCount = query.Count();
        var pagedList = query.Skip(request.Skip).Take(request.PerPage).ToList();
        var dtoList = _mapper.Map<List<AddressDetailDto>>(pagedList);
        return new(dtoList, totalCount, request);
    }

    public ServiceResponse<AddressDetailDto?> GetById(int id)
    {
        var entity = _userAddressRepository.GetById(id);
        if (entity == null)
            return new("Not Found!");
        var dto = _mapper.Map<AddressDetailDto>(entity);
        return new(dto);
    }

    public ServiceResponse<AddressCreateOrUpdateDto?> GetForEditById(int id)
    {
        var entity = _userAddressRepository.GetById(id);
        var dto = _mapper.Map<AddressCreateOrUpdateDto>(entity);
        return new(dto);
    }

    public ServiceResponse<bool> Insert(AddressCreateOrUpdateDto dto)
    {
        var entity = _mapper.Map<UserAddress>(dto);
        return new(_userAddressRepository.Insert(entity));
    }

    public ServiceResponse<bool> Update(AddressCreateOrUpdateDto dto)
    {
        var entity = _mapper.Map<UserAddress>(dto);
        return new(_userAddressRepository.Update(entity));
    }

    public ServiceResponse<bool> Delete(AddressDetailDto dto)
    {
        var entity = _mapper.Map<UserAddress>(dto);
        return new(_userAddressRepository.Delete(entity));
    }

    public ServiceResponse<bool> DeleteById(int id)
    {
        return new(_userAddressRepository.DeleteById(id));
    }
}