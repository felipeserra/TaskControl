using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task.Domain.Models.Entity;

namespace TaskControl.Infra.Data.DataContext.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Name)
                .HasColumnType("VARCHAR(80)")
                .HasMaxLength(80)
                .IsRequired();

            builder
                .Property(x => x.Email)
                .HasColumnType("VARCHAR(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x => x.Password)
                .HasColumnType("VARCHAR(32)")
                .HasMaxLength(32);
        }
    }
}