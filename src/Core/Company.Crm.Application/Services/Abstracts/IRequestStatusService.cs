using Company.Crm.Domain.Entities.Lst;
namespace Company.Crm.Application.Services.Abstracts
{
    public interface IRequestStatusService
    {
        public List<RequestStatus> GetAll();
        public RequestStatus? GetById(int id);
        public bool Insert(RequestStatus entity);
        public bool Update(RequestStatus entity);
        public bool Delete(RequestStatus entity);
        public bool DeleteById(int id);
    }
}
