using Agricultural.Domain.Entity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class User_BankConfiguration : IEntityTypeConfiguration<User_Bank>
    {
        
        public void Configure(EntityTypeBuilder<User_Bank> builder)
        {

            builder.HasOne(x => x.Banks).WithMany(f => f.User_Bank).IsRequired(false).HasForeignKey(x => x.BanksId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
