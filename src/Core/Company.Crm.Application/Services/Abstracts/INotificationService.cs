using Company.Crm.Domain.Entities;

namespace Company.Crm.Application.Services.Abstracts;

public interface INotificationService
{
    public List<Notification> GetAll();
    public Notification? GetById(int id);
    public bool Insert(Notification entity);
    public bool Update(Notification entity);
    public bool Delete(Notification entity);
    public bool DeleteById(int id);
}