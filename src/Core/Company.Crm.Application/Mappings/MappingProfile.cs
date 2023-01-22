using AutoMapper;
using Company.Crm.Application.Dtos;
using Company.Crm.Application.Dtos.Address;
using Company.Crm.Application.Dtos.List;
using Company.Crm.Application.Dtos.Notification;
using Company.Crm.Application.Dtos.Sale;
using Company.Crm.Application.Dtos.UserAddress;
using Company.Crm.Application.Dtos.UserEmail;
using Company.Crm.Application.Dtos.UserPhone;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Entities.Lst;

namespace Company.Crm.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // CreateMap: Customer nesnesini CustomerDto'ya dönüştürme ayarını yapar.
        // ReverseMap: CustomerDto nesnesini otomatik Customer'a dönüştürmeyi sağlar. İki satır yazmak yerine ReverseMap kullanılır.
        CreateMap<Customer, CustomerDto>()
            .ForMember(d => d.StatusTypeName, m => m.MapFrom(s => s.StatusTypeFk != null ? s.StatusTypeFk.Name : ""))
            .ForMember(d => d.GenderName, m => m.MapFrom(s => s.GenderFk != null ? s.GenderFk.Name : ""))
            .ForMember(d => d.TitleName, m => m.MapFrom(s => s.TitleFk != null ? s.TitleFk.Name : ""))
            .ForMember(d => d.UserFullName, m => m.MapFrom(s => s.UserFk != null ? s.UserFk.Name + " " + s.UserFk.Surname : ""))
            .ReverseMap();
        CreateMap<CustomerDto, Customer>();
        CreateMap<Customer, CreateOrUpdateCustomerDto>().ReverseMap();

        CreateMap<Gender, GenderDto>().ReverseMap();

        CreateMap<Employee, EmployeeDto>()
            .ForMember(d => d.TitleName, m => m.MapFrom(s => s.TitleFk != null ? s.TitleFk.Name : ""))
            .ForMember(d => d.UserFullName, m => m.MapFrom(s => s.UserFk != null ? s.UserFk.Name + " " + s.UserFk.Surname : ""))
            .ReverseMap();
        CreateMap<Employee, CreateOrUpdateEmployeeDto>().ReverseMap();

        CreateMap<Notification, NotificationCreateOrUpdateDto>().ReverseMap();
        CreateMap<Notification, NotificationDetailDto>().ReverseMap();

        CreateMap<UserAddress, AddressDetailDto>().ReverseMap();
        CreateMap<UserAddress, AddressCreateOrUpdateDto>().ReverseMap();

        CreateMap<UserPhone, UserPhoneDto>().ReverseMap();
        CreateMap<UserPhone, CreateOrUpdateUserPhoneDto>().ReverseMap();

        CreateMap<UserEmail, UserEmailDto>().ReverseMap();
        CreateMap<UserEmail, CreateOrUpdateUserEmailDto>().ReverseMap();

        CreateMap<Sale, SaleDetailDto>().ReverseMap();
        CreateMap<Sale, CreateOrUpdateSaleDto>().ReverseMap();

    }
}