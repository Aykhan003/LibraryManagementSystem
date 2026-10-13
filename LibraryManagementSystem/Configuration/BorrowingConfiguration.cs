using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Configuration;

public class BorrowingConfiguration : IEntityTypeConfiguration<Borrowing>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Borrowing> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.BorrowDate).IsRequired();
        builder.Property(b => b.ReturnDate).IsRequired();
        builder.Property(b => b.MemberId).IsRequired();
        builder.Property(b => b.BookId).IsRequired();
        builder.HasOne(b => b.Member)
            .WithMany(m => m.Borrowings)
            .HasForeignKey(b => b.MemberId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(b => b.Book)
            .WithMany(bk => bk.Borrowings)
            .HasForeignKey(b => b.BookId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
