using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrueCode.Domain.Entities;
using TrueCode.Infrastructure.Configurations.Common;

namespace TrueCode.Infrastructure.Configurations;
internal class UserConfiguration : EntityConfig<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.Domain)
            .IsRequired();
    }
}
