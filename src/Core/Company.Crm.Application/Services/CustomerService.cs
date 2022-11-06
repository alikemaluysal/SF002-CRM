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

        public List<CustomerDto> GetAllCustomers()
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

        public CustomerDto? GetCustomerById(int id)
        {
            var entity = _customerRepository.GetById(id);
            var dto = _mapper.Map<CustomerDto>(entity);
            return dto;
        }

        public bool InsertCustomer(CreateOrUpdateCustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);

            return _customerRepository.Insert(customer);
        }

        public bool UpdateCustomer(CreateOrUpdateCustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);

            return _customerRepository.Update(customer);
        }

        public bool DeleteCustomer(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);

            return _customerRepository.Delete(customer);
        }

        public bool DeleteCustomerById(int id)
        {
            return _customerRepository.DeleteById(id);
        }

        public List<CustomerDto> GetAllCustomersByRegionId(int regionId)
        {
            var entityList = _customerRepository.GetAllByRegionId(regionId);
            var dtoList = _mapper.Map<List<CustomerDto>>(entityList);
            return dtoList;
        }
    }
}
