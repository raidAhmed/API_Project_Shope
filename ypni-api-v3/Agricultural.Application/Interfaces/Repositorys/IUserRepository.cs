/////////////////////////////////////
///         Ibrahim AL-afif       ///
///         ib2050a@gmail.com     ///
///         +967 777 384 772      ///
// generated IUser.cs //
/////////////////////////////////////////
using Agricultural.Domain.Entity;
using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.User;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IUserRepository : IGenericRepository<User>
    {

    


        Task<IEnumerable<UserDDLViewModel>> GetDDL();


    }
}

