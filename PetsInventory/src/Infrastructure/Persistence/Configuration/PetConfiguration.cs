using Domain.Pets;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("Pets");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id).HasConversion(
            petId => petId.Value,
            value => new PetId(value));
        
        builder.Property(p => p.Name).HasMaxLength(100);

        builder.Property(p => p.Breed).HasMaxLength(50);

        builder.Property(p => p.Color).HasMaxLength(20);

        builder.Property(p => p.BirthDate).HasConversion(
            birthdate => birthdate!.Value,
            value => Year.Create(value)!)
            .HasMaxLength(4);
        
        builder.Property(p => p.DeathDate).HasConversion(
            deathdate => deathdate!.Value,
            value => Year.Create(value)!)
            .HasMaxLength(4);
        
        builder.Property(p => p.IsSterilized);
    }
}
