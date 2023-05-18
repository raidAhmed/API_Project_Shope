using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Markets;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IMarketsRepository: IGenericRepository<Markets>
    {
       
        Task<IEnumerable<MarketsDDlLViewModels>> GetDDL();
    }
}
