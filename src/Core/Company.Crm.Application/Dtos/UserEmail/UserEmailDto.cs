using Company.Framework.Dtos;

namespace Company.Crm.Application.Dtos.UserEmail
{
    public class UserEmailDto : BaseDto
    {
        public int UserId { get; set; }
        public string EmailAddress { get; set; }
        public string EmailType { get; set; }
    }
}

