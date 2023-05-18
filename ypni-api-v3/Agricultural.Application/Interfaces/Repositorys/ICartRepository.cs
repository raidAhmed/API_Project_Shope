using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Cart;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface ICartRepository: IGenericRepository<Cart>
    {
     
        Task<IEnumerable<CartDDlLViewModels>> GetDDL();
    }
}
