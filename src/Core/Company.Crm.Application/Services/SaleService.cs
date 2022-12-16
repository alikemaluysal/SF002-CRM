using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;

namespace Company.Crm.Application.Services
{
    public class SaleService : ISaleService
    {
        readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {

            _saleRepository = saleRepository;
        }

        public bool Insert(Sale entity)
        {
            return _saleRepository.Insert(entity);
        }

        public bool Delete(Sale entity)
        {
            return _saleRepository.Delete(entity);
        }

        public bool DeleteById(int id)
        {
            return _saleRepository.DeleteById(id);
        }

        public List<Sale> GetAll()
        {
            return _saleRepository.GetAll().ToList();
        }

        public Sale? GetById(int id)
        {
            return _saleRepository.GetById(id);
        }

        public List<Sale> GetPaged(int page, int size)
        {
            return _saleRepository.GetAll().Skip(page * size).Take(size).ToList();
        }

        public bool Update(Sale entity)
        {
            var sale = _saleRepository.GetById(entity.Id);
            sale.CustomerId = entity.CustomerId;
            sale.Price = entity.Price;
            sale.EmployeeId = entity.EmployeeId;
            sale.Price = entity.Price;
            sale.OfferId = entity.OfferId;
            sale.IsCompleted = entity.IsCompleted;
            //notification = _mapper.Map<Notification>(dto); // save için repository çağırıldı.update ile mapper aynı anda kullanıldığında dtodan gelmeyen fieldları null yapıyor.
            return _saleRepository.Update(sale);
        }
    }
}
