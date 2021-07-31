using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreApp.Entities;

namespace StoreApp.Data.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder) 
        {
            builder.ToTable("category")
                .HasKey(c => c.CategoryId);
            builder.Property(c => c.CategoryId)
                .HasColumnName("category_id");
            builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(c => c.Description)
                .HasColumnName("description")
                .HasMaxLength(250)
                .IsUnicode(false);
            builder.Property(c => c.Condition)
                .HasColumnName("condition")
                .HasDefaultValueSql("((1))");
        }
    }
}
