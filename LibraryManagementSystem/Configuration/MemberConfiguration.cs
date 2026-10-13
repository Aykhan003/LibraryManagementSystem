using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Configuration;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Member> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.FullName).IsRequired().HasMaxLength(100);
        builder.HasIndex(m => m.Email).IsUnique();
        builder.Property(m => m.PhoneNumber).HasMaxLength(15);
        builder.HasMany(m => m.Borrowings)
            .WithOne(bb => bb.Member)
            .HasForeignKey(bb => bb.MemberId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
