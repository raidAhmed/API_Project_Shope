using Agricultural.Application.DTOs.ComplainantToParty;
using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class ComplainantToPartyRepository : GenericRepository<ComplainantToParty>, IComplainantToPartyRepository
    {
        public ComplainantToPartyRepository(ApplicationDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<ComplainantToPartyQueryDto>> GetDDL()
        {
            return await Task.FromResult(_context.Set<ComplainantToParty>().Select(x => new ComplainantToPartyQueryDto
            {
                Id = x.Id,
                Topic = x.Topic,
                TypeofMesseage = x.TypeofMesseage,
                SenderId = x.SenderId,
                ReciverId = x.ReciverId,
                requestState = x.requestState,
                Active = x.Active,
            }));
        }
    }
}
