using Company.Crm.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Application.Services.Abstracts
{
    public interface IRequestService
    {
        public List<RequestDto> GetAll();
        public RequestDto? GetById(int id);
        public bool Insert(RequestDto entity);
        public bool Update(RequestDto entity);
        public bool Delete(RequestDto entity);
        public bool DeleteById(int id);
    }
}
