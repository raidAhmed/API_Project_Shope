


using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;
using Agricultural.Application.ViewModels.User;

namespace Agricultural.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
                public async ValueTask<User?> GetById(string Id)
        {
            return await _context.Set<User>().FindAsync(Id);
        }


        public async Task<IEnumerable<UserDDLViewModel>> GetDDL()
        {
            return await Task.FromResult(_context.Set<User>().Select(x=> new UserDDLViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                }));
        }

        
    }
}
