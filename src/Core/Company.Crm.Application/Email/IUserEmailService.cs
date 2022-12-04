﻿namespace Company.Crm.Application.UserEmail;

public interface IUserEmailService
{
    Task RegisterMailAsync(string email, string name);
    Task ConfirmationMailAsync(string link, string email);
    Task RemindPasswordMailAsync(string link, string email);
}