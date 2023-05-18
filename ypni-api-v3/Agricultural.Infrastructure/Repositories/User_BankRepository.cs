using Agricultural.Application.Interfaces.Repositorys;
using Agricultural.Domain.Entity;
using Agricultural.Infrastructure.DbContexts;

namespace Agricultural.Infrastructure.Repositories
{
    public class User_BankRepository : GenericRepository<User_Bank>,IUser_BankRepository
    {
        public User_BankRepository(ApplicationDbContext context) : base(context)
        {
        }


    }
}
