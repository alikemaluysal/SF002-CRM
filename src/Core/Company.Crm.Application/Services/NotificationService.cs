using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;

namespace Company.Crm.Application.Services;

public class NotificationService : INotificationService
{
    private readonly INotificationRepository _notificationRepository;

    public NotificationService(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public List<Notification> GetAll()
    {
        return _notificationRepository.GetAll();
    }

    public Notification? GetById(int id)
    {
        return _notificationRepository.GetById(id);
    }

    public bool Insert(Notification entity)
    {
        return _notificationRepository.Insert(entity);
    }

    public bool Update(Notification entity)
    {
        return _notificationRepository.Update(entity);
    }

    public bool Delete(Notification entity)
    {
        return _notificationRepository.Delete(entity);
    }

    public bool DeleteById(int id)
    {
        return _notificationRepository.DeleteById(id);
    }
}