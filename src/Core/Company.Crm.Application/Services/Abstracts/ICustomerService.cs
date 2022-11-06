using Company.Crm.Application.Dtos;

namespace Company.Crm.Application.Services.Abstracts
{
    public interface ICustomerService
    {
        public List<CustomerDto> GetAllCustomers();
        public CustomerDto? GetCustomerById(int id);
        public bool InsertCustomer(CreateOrUpdateCustomerDto customerDto);
        public bool UpdateCustomer(CreateOrUpdateCustomerDto customerDto);
        public bool DeleteCustomer(CustomerDto customerDto);
        public bool DeleteCustomerById(int id);
        public List<CustomerDto> GetAllCustomersByRegionId(int regionId);
    }
}