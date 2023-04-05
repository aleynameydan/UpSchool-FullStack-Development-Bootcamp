using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations.Application;

public class AddressConfiguration:IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.Property(x => x.AddressType).IsRequired();
        builder.Property(x => x.AddressType).HasConversion<int>();
        
        //Relationships
        builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);
    }
}