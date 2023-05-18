using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Agricultural.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agricultural.Infrastructure.EntityConfiguration
{
    internal class SP_User_FavouritesConfigration : IEntityTypeConfiguration<SP_User_Favourites>
    {
        public void Configure(EntityTypeBuilder<SP_User_Favourites> builder)
        {
            builder.HasOne(x=>x.User).WithMany(f=>f.SP_User_Favourites).HasForeignKey(x=>x.UserId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(x=>x.ServiceProvider).WithMany(f=>f.sP_User_Favourites).HasForeignKey(x=>x.ServiceProviderId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
