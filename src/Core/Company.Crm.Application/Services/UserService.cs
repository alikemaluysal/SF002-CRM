using Company.Crm.Application.Dtos;
using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Application.UserEmail;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Enums;
using Company.Crm.Domain.Repositories;
using Company.Framework.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Company.Crm.Application.Services;

public class UserService : IUserService
{
    private readonly IConfiguration _configuration;
    private readonly IUserEmailService _userEmailService;
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository, IUserEmailService userEmailService, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _userEmailService = userEmailService;
        _configuration = configuration;
    }

    public List<User> GetAll()
    {
        return _userRepository.GetAll().ToList();
    }

    public User? GetById(int id)
    {
        return _userRepository.GetById(id);
    }

    public bool Insert(User entity)
    {
        return _userRepository.Insert(entity);
    }

    public bool Update(User entity)
    {
        return _userRepository.Update(entity);
    }

    public bool Delete(User entity)
    {
        return _userRepository.Delete(entity);
    }

    public bool DeleteById(int id)
    {
        return _userRepository.DeleteById(id);
    }

    public User? Login(LoginDto dto)
    {
        var user = _userRepository.GetAll()
            .Include(c => c.Roles)
            .Where(c => c.Username == dto.EmailAddressOrUsername || c.Email == dto.EmailAddressOrUsername)
            .Where(c => c.UserStatusId == (int)UserStatusEnum.Active) // Email Activation
            .FirstOrDefault();

        if (user != null)
            if (SecurityHelper.HashValidate(user.Password, dto.Password))
                return user;

        return null;
    }

    public User? Register(RegisterDto dto)
    {
        var user = new User
        {
            Name = dto.Name,
            Surname = dto.Surname,
            Username = dto.Name.ToLower() + dto.Surname.ToLower(),
            Email = dto.EmailAddress,
            Password = SecurityHelper.HashCreate(dto.Password),
            UserStatusId = 0 // Pasif
        };

        var isCreated = _userRepository.Insert(user);
        if (isCreated)
        {
            // Register Mail
            _userEmailService.RegisterMailAsync(dto.EmailAddress, dto.Name).GetAwaiter().GetResult();

            // Email Activation
            var activationKey = SecurityHelper.CreateMd5(dto.EmailAddress);
            var link = $"{_configuration["App:SiteUrl"]}/Auth/EmailActivation?email={dto.EmailAddress}&activationKey={activationKey}";

            _userEmailService.ConfirmationMailAsync(link, dto.EmailAddress);

            return user;
        }

        return null;
    }

    public bool ActivateUserByEmail(string email, string activationKey)
    {
        var emailMd5 = SecurityHelper.CreateMd5(email);
        if (emailMd5 == activationKey)
        {
            var user = _userRepository.GetAll().Where(e => e.Email == email).FirstOrDefault();
            if (user != null)
            {
                user.UserStatusId = 1;
                return _userRepository.Update(user);
            }
        }

        return false;
    }

    public User? GetByEmail(string email)
    {
        var user = _userRepository.GetAll()
            .Include(c => c.Roles)
            .FirstOrDefault(c => c.Username == email || c.Email == email);

        return user;
    }

    public void RemindPassword(RemindPasswordDto dto)
    {
        var user = GetByEmail(dto.EmailAddress);
        if (user != null)
        {
            var resetKey = SecurityHelper.CreateMd5(dto.EmailAddress);
            var link = $"{_configuration["App:SiteUrl"]}/Auth/ResetPassword?email={dto.EmailAddress}&resetKey={resetKey}";

            _userEmailService.RemindPasswordMailAsync(link, dto.EmailAddress);
        }
    }

    public void ResetPassword(ResetPasswordDto dto)
    {
        var user = _userRepository.GetAll().FirstOrDefault(e => e.Email == dto.EmailAddress);
        if (user != null && dto.Password == dto.PasswordRepeat)
        {
            user.Password = SecurityHelper.HashCreate(dto.Password);

            _userRepository.Update(user);
        }
    }
}