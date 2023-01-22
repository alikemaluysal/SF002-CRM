using Company.Crm.Application.Dtos;
using Company.Crm.Application.Dtos.Notification;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Application.Validators
{
    public class RequestValidator : AbstractValidator<RequestCreateOrUpdateDto>
    {
        public RequestValidator()
        {
            RuleFor(t => t.CustomerUserId).NotNull(); //.WithMessage("UserId is required!");

            RuleFor(t => t.Description).NotNull().NotEmpty().MaximumLength(50);

            RuleFor(t => t.EmployeeUserId).NotNull();
        }

       
    }
}
