using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.ConsultationRequest;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class ConsultationRequestRepository : GenericRepository<ConsultationRequest>,IConsultationRequestRepository
    {
        public ConsultationRequestRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<ConsultationRequestDDlLViewModels>> GetDDL()
        {
            return await Task.FromResult(_context.Set<ConsultationRequest>().Select(x => new ConsultationRequestDDlLViewModels
            {
                Id = x.Id,
                Topic = x.Topic
            }));
        }
    }
}
