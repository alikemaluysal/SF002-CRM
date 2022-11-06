using AutoMapper;
using Company.Crm.Application.Dtos;
using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;

namespace Company.Crm.Application.Services
{
    // Concrete-Abstract
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public List<CustomerDto> GetAll()
        {
            var entityList = _customerRepository.GetAll();

            #region Old
            //var dtoList = new List<CustomerDto>();
            //foreach (var item in list)
            //{
            //    dtoList.Add(new CustomerDto
            //    {
            //        Id = item.Id,
            //        TitleName = "Developer",
            //        CompanyName = item.CompanyName,
            //        GenderId = item.GenderId,
            //        TitleId = item.TitleId
            //    });
            //}
            #endregion

            var dtoList = _mapper.Map<List<CustomerDto>>(entityList);

            return dtoList;
        }

        public CustomerDto? GetById(int id)
        {
            var entity = _customerRepository.GetById(id);
            var dto = _mapper.Map<CustomerDto>(entity);
            return dto;
        }

        public bool Insert(CreateOrUpdateCustomerDto dto)
        {
            var customer = _mapper.Map<Customer>(dto);

            return _customerRepository.Insert(customer);
        }

        public bool Update(CreateOrUpdateCustomerDto dto)
        {
            var customer = _mapper.Map<Customer>(dto);

            return _customerRepository.Update(customer);
        }

        public bool Delete(CustomerDto dto)
        {
            var customer = _mapper.Map<Customer>(dto);

            return _customerRepository.Delete(customer);
        }

        public bool DeleteById(int id)
        {
            return _customerRepository.DeleteById(id);
        }

        public List<CustomerDto> GetAllByRegionId(int regionId)
        {
            var entityList = _customerRepository.GetAllByRegionId(regionId);
            var dtoList = _mapper.Map<List<CustomerDto>>(entityList);
            return dtoList;
        }
    }
}
