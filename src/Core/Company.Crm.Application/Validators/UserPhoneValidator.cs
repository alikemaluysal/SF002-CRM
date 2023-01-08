using Company.Crm.Application.Dtos;
using Company.Crm.Application.Dtos.UserPhone;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Crm.Application.Validators
{
    public class UserPhoneValidator : AbstractValidator<CreateOrUpdateUserPhoneDto>
    {
        public UserPhoneValidator()
        {
            RuleFor(t => t.UserId).NotNull(); 

            RuleFor(t => t.PhoneNumber).NotNull();
            RuleFor(t => t.PhoneType).NotNull();

        }

        
        }
    }

