using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Application.ViewModels.ComplainantPic;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class ComplainantPicRepository : GenericRepository<ComplainantPic>,IComplainantPicRepository
    {
        public ComplainantPicRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<ComplainantPicDDlLViewModels>> GetDDL()
        {
            return await Task.FromResult(_context.Set<ComplainantPic>().Select(x => new ComplainantPicDDlLViewModels
            {
                Id = x.Id,
               Image  = x.Image
            }));
        }
    }
}
