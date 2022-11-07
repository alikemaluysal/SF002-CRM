using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Application.Services
{
    public class AddressService : IAddressService
    {
        readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        // => : expression bodied members 
        //Expression Bodied makes the type member(Constructor, Destructor, Methods, Property, Indexer) defined in a single expression.
        /*https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members */
        public List<Address> GetAll() =>
             _addressRepository.GetAll();
        public Address? GetById(int id) =>
             _addressRepository.GetById(id);
        public bool Insert(Address entity) =>
           _addressRepository.Insert(entity);
        public bool Update(Address entity) =>
          _addressRepository.Update(entity);
        public bool Delete(Address entity) =>
             _addressRepository.Delete(entity);
        public bool DeleteById(int id) =>
             _addressRepository.DeleteById(id);
    }
}
