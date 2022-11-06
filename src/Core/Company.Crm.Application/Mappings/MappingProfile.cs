using AutoMapper;
using Company.Crm.Application.Dtos;
using Company.Crm.Domain.Entities;

namespace Company.Crm.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CreateMap: Customer nesnesini CustomerDto'ya dönüştürme ayarını yapar.
            // ReverseMap: CustomerDto nesnesini otomatik Customer'a dönüştürmeyi sağlar. İki satır yazmak yerine ReverseMap kullanılır.
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CreateOrUpdateCustomerDto>().ReverseMap();

            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, CreateOrUpdateEmployeeDto>().ReverseMap();
        }
    }
}
