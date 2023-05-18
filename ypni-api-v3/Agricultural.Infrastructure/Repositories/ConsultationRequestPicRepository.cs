using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.ConsultationRequestPic;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class ConsultationRequestPicRepository : GenericRepository<ConsultationRequestPic>,IConsultationRequestPicRepository
    {
        public ConsultationRequestPicRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<ConsultationRequestPicDDlLViewModels>> GetDDL()
        {
            return await Task.FromResult(_context.Set<ConsultationRequestPic>().Select(x => new ConsultationRequestPicDDlLViewModels
            {
                Id = x.Id,
                Image = x.Image
            }));
        }
    }
}
