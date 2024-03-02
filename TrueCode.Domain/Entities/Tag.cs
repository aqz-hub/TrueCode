using TrueCode.Domain.Common;

namespace TrueCode.Domain.Entities;
public sealed class Tag : Entity
{
    public string Value { get; set; } = default!;
    public string Domain { get; set; } = default!;
    public List<TagToUser>? TagToUsers { get; set; }
}
