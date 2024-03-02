using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrueCode.Domain.Common;

namespace TrueCode.Infrastructure.Configurations.Common;
internal class EntityConfig<T> : IEntityTypeConfiguration<T> where T : Entity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedNever();
    }
}
