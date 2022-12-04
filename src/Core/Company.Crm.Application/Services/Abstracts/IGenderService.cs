using Company.Crm.Application.Dtos;
using Company.Crm.Domain.Entities;

namespace Company.Crm.Application.Services.Abstracts
{
    public interface IGenderService
    {
        public List<GenderDto> GetAll();

        public GenderDto? GetById(int id);

        public bool Insert(GenderDto entity);

        public bool Update(GenderDto entity);

        public bool Delete(GenderDto entity);

        public bool DeleteById(int id);
    }
}