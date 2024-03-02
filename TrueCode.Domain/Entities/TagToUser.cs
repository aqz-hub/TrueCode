using TrueCode.Domain.Common;

namespace TrueCode.Domain.Entities;
public sealed class TagToUser : Entity
{
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public Guid TagId { get; set; }
    public Tag? Tag { get; set; }
}
