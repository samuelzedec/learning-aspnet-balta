using Dima.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Data.Mappings;

public class TransactionMapping : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transaction");

        builder
            .HasKey(x => x.Id)
            .HasName("PK_Transaction_Id");

        builder
            .Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("BIGINT")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        
        builder
            .Property(x => x.Title)
            .HasColumnName("Title")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80)
            .IsRequired();
        
        builder
            .Property(x => x.Type)
            .HasColumnName("Type")
            .HasColumnType("SMALLINT")
            .IsRequired();
        
        builder
            .Property(x => x.Amount)
            .HasColumnName("Amount")
            .HasColumnType("MONEY")
            .IsRequired();

        builder
            .Property(x => x.CreatedAt)
            .HasColumnName("CreatedAt")
            .HasColumnType("DATETIME2")
            .IsRequired();

        builder
            .Property(x => x.PaidOrReceiveAt)
            .HasColumnName("PaidOrReceiveAt")
            .HasColumnType("DATETIME2")
            .IsRequired(false);
        
        builder
            .HasOne(x => x.Category)
            .WithMany()
            .HasForeignKey(x => x.CategoryId)
            .HasConstraintName("FK_Transaction_CategoryId");
        
        builder
            .Property(x => x.UserId)
            .HasColumnName("UserId")
            .HasColumnType("VARCHAR")
            .HasMaxLength(160)
            .IsRequired();
    }
}