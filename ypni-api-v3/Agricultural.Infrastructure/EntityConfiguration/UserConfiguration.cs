using Agricultural.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Agricultural.Infrastructure.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("AspNetUsers", "dbo");
            builder.Property(x => x.Image).HasColumnName(@"Image").HasColumnType("nvarchar(255)").IsRequired(false).HasMaxLength(255);
            var hasher = new PasswordHasher<User>();
            builder.HasData(
                  new User
                  {
                      Id = "4a2e1650-21bd-4e67-832e-2e99c267a2e4",
                      UserName = "Quantum",
                      Email = "Agricultural@Gmail.com",
                      FirstName = "شركة",
                      LastName = "كوانتم",
                      Active = true,
                      Status = true,
                      Image = "Upload/Users/d765abae-79c2-4ff8-975e-fb9e5578aa5c.jpg",
                      NormalizedUserName = "QUANTUM",
                      NormalizedEmail = "AGRICULTURAL@GMAIL.COM",
                      PasswordHash = hasher.HashPassword(null, "Pa$$w0rd"),

                  }

             );
        }
    }
}
