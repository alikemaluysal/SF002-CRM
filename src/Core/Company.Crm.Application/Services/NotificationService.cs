using AutoMapper;
using Company.Crm.Application.Dtos.Notification;
using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Repositories;

namespace Company.Crm.Application.Services;

public class NotificationService : INotificationService
{
    private readonly IMapper _mapper;
    private readonly INotificationRepository _notificationRepository;

    public NotificationService(INotificationRepository notificationRepository, IMapper mapper)
    {
        _notificationRepository = notificationRepository;
        _mapper = mapper;
    }

    public NotificationCreateOrUpdateDto GetForEditById(int id)
    {
        var notification = _notificationRepository.GetById(id);

        var dto = _mapper.Map<NotificationCreateOrUpdateDto>(notification);
        return dto;
    }

    public List<NotificationDetailDto> GetPaged(int page = 1)
    {
        var entityList = _notificationRepository.GetAll().OrderBy(c => c.IsRead);
        var pagedList = entityList.Skip((page - 1) * 10).Take(10).Select(x => new NotificationDetailDto
        {
            Id = x.Id,
            UserId = x.UserId,
            Title = x.Title,
            CreatedAt = x.CreatedAt,
            CreatedBy = x.CreatedBy,
            Text = x.Text,
            IsRead = x.IsRead
        }).ToList();
        return pagedList;
    }

    public List<NotificationDetailDto> GetAll()
    {
        return _notificationRepository.GetAll().Select(x => new NotificationDetailDto
        {
            Id = x.Id,
            IsRead = x.IsRead,
            CreatedAt = x.CreatedAt,
            Text = x.Text,
            Title = x.Title,
            UserId = x.UserId
        }).ToList();
    }

    public NotificationDetailDto? GetById(int id)
    {
        var notification = _mapper.Map<NotificationDetailDto>(_notificationRepository.GetById(id));
        return notification;
    }

    public bool Insert(NotificationCreateOrUpdateDto entity)
    {
        return _notificationRepository.Insert(new Notification
        {
            Title = entity.Title,
            Text = entity.Text,
            UserId = entity.UserId,
            CreatedBy = entity.UserId
        });
    }

    public bool Update(NotificationCreateOrUpdateDto dto)
    {
        var notification = _notificationRepository.GetById(dto.Id);
        notification.UserId = dto.UserId;
        notification.Text = dto.Text;
        notification.Title = dto.Title;
        notification.CreatedBy = dto.UserId;
        //notification = _mapper.Map<Notification>(dto); // save için repository çağırıldı.update ile mapper aynı anda kullanıldığında dtodan gelmeyen fieldları null yapıyor.
        return _notificationRepository.Update(notification);
    }

    public bool Delete(Notification entity)
    {
        return _notificationRepository.Delete(entity);
    }

    public bool DeleteById(int id)
    {
        return _notificationRepository.DeleteById(id);
    }

    public bool MarkAsRead(int id)
    {
        var notification = _notificationRepository.GetById(id);
        if (notification != null)
        {
            notification.IsRead = !notification.IsRead;
            return _notificationRepository.Update(notification); //save yapabilmek için /servislerden çağırmak için repositorye save methodu eklenebilir ? 
        }

        return false;
    }
}