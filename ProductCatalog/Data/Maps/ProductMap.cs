using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Models;

namespace ProductCatalog.Data.Maps
{
    public class ProductMap: IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(x => x.IdProduct);  
            builder.Property(x => x.Title).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.Property(x => x.Description).IsRequired().HasMaxLength(1024).HasColumnType("varchar(1024)");
            builder.Property(x => x.Price).IsRequired().HasColumnType("money");
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Image).IsRequired().HasMaxLength(1024).HasColumnType("varchar(1024)");
            builder.Property(x => x.CreateDate).IsRequired();
            builder.Property(x => x.LastUpdateDate).IsRequired();
            builder.HasOne(x => x.Category).WithMany(x => x.Products); //Uma categoria para muitos produtos
            //Como nessa classe já está sendo feita o relacionamento da categoria com o produto
            //Não é necessario fazer a mesma coisa na classe CategoryMap
            //Se colocar nas duas classes não tem problema, mas não é necessario
        }
    }
}
