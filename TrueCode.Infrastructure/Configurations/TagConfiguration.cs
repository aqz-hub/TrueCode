using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrueCode.Domain.Entities;
using TrueCode.Infrastructure.Configurations.Common;

namespace TrueCode.Infrastructure.Configurations;
internal class TagConfiguration : EntityConfig<Tag>
{
    public override void Configure(EntityTypeBuilder<Tag> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Value)
            .IsRequired();

        builder.Property(x => x.Domain)
            .IsRequired();  
    }
}
