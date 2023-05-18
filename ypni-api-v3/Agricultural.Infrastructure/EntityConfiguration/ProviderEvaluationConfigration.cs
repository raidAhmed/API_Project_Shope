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
    internal class ProviderEvaluationConfigration : IEntityTypeConfiguration<ProviderEvaluation>
    {
        public void Configure(EntityTypeBuilder<ProviderEvaluation> builder)
        {
            builder.HasOne(x => x.User).WithMany(f => f.providerEvaluations).HasForeignKey(c => c.UserId);
            builder.HasOne(x => x.ServiceProvider).WithMany(f => f.providerEvaluations).HasForeignKey(c => c.ServiceProviderId);
        }
    }
}
