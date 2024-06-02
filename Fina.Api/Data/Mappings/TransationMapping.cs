using Fina.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fina.Api.Data.Mappings;

public class TransationMapping:IEntityTypeConfiguration<Transation>
{
    public void Configure(EntityTypeBuilder<Transation> builder)
    {
        builder.ToTable("Transation");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title)
            .IsRequired()
            .HasColumnType("nvarchar")
            .HasMaxLength(80);
        
        builder.Property(x => x.Type)
            .IsRequired()
            .HasColumnType("smallint")
            .HasMaxLength(255);
        builder.Property(x => x.Amonut)
            .IsRequired()
            .HasColumnType("money");
        
        builder.Property(x => x.CreatedAt)
            .IsRequired();
        
        builder.Property(x => x.PaidOrreceivedAt)
            .IsRequired(false);
        
        builder.Property(x => x.UserId)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(160);
        
    }
}