using Company.Crm.Application.Dtos.Notification;
using Company.Crm.Domain.Entities;

namespace Company.Crm.Application.Services.Abstracts;

public interface INotificationService
{
	List<NotificationDetailDto> GetPaged(int page = 1);
	List<NotificationDetailDto> GetAll();
	NotificationDetailDto? GetById(int id);
	NotificationCreateOrUpdateDto GetForEditById(int id);
	bool Insert(NotificationCreateOrUpdateDto entity);
	bool Update(NotificationCreateOrUpdateDto entity);
	bool Delete(Notification entity);
	bool DeleteById(int id);
	bool MarkAsRead(int id);
}
