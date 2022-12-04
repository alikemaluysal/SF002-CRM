using Company.Framework.Entity;

namespace Company.Crm.Domain.Entities.Usr;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int? UserStatusId { get; set; }

    public ICollection<Role> Roles { get; set; }
}