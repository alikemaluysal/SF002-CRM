using Company.Crm.Domain.Entities;

namespace Company.Crm.Application.Services.Abstracts
{
    public interface ISaleService
    {
        public List<Sale> GetAll();
        public List<Sale> GetPaged(int page, int size);

        public Sale? GetById(int id);
        public bool Insert(Sale entity);
        public bool Update(Sale entity);
        public bool Delete(Sale entity);
        public bool DeleteById(int id);
    }
}
