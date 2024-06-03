using Fina.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fina.Api.Data.Mappings;

public class CategoryMapping:IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasColumnType("nvarchar")
            .HasMaxLength(80);
        
        builder.Property(x => x.Description)
            .IsRequired()
            .HasColumnType("nvarchar")
            .HasMaxLength(255);
        
        builder.Property(x => x.UserId)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(160);
        
        
        
    }
}