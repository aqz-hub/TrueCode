using TrueCode.Domain.Common;

namespace TrueCode.Domain.Entities;
public sealed class User : Entity
{
    public string Name { get; set; } = default!;
    public string Domain { get; set; } = default!;
    public List<TagToUser>? TagToUsers { get; set; }
}
