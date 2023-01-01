using AutoMapper;
using Company.Crm.Application.Dtos.Sale;
using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;

namespace Company.Crm.Application.Services
{
	public class SaleService : ISaleService
	{
		readonly ISaleRepository _saleRepository;
		readonly IMapper _mapper;
		public SaleService(ISaleRepository saleRepository, IMapper mapper)
		{
			_saleRepository = saleRepository;
			_mapper = mapper;
		}

		public bool Insert(CreateOrUpdateSaleDto entity)
		{
			var sale = _mapper.Map<Sale>(entity);
			return _saleRepository.Insert(sale);
		}

		public bool Delete(SaleDetailDto entity)
		{
			var sale = _mapper.Map<Sale>(entity);
			return _saleRepository.Delete(sale);
		}

		public bool DeleteById(int id)
		{
			return _saleRepository.DeleteById(id);
		}

		public List<SaleDetailDto> GetAll()
		{
			var entityList = _saleRepository.GetAll();
			return entityList.Select(x => new SaleDetailDto
			{
				Id = x.Id,
				Description = x.Description,
				EmployeeUserId = x.EmployeeUserId,
				RequestId = x.RequestId,
				SaleAmount = x.SaleAmount,
				SaleDate = x.SaleDate,
			}).ToList();
		}

		public SaleDetailDto? GetById(int id)
		{
			var entity = _saleRepository.GetById(id);
			return _mapper.Map<SaleDetailDto>(entity);
		}

		public List<SaleDetailDto> GetPaged(int page)
		{
			var entityList = _saleRepository.GetAll()
		   .OrderByDescending(c => c.Id);

			var pagedList = entityList.Skip((page - 1) * 10).Take(10).ToList();
			return _mapper.Map<List<SaleDetailDto>>(pagedList);
		}

		public bool Update(CreateOrUpdateSaleDto entity)
		{
			var sale = _saleRepository.GetById(entity.Id);
			sale.RequestId = entity.RequestId;
			sale.EmployeeUserId = entity.EmployeeUserId;
			sale.SaleDate = entity.SaleDate;
			sale.SaleAmount = entity.SaleAmount;
			sale.Description = entity.Description;
			return _saleRepository.Update(sale);
		}

		public CreateOrUpdateSaleDto GetForEditById(int id)
		{
			var sale = _saleRepository.GetById(id);
			return _mapper.Map<CreateOrUpdateSaleDto>(sale);
		}
	}
}
