using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Offer;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IOfferRepository: IGenericRepository<Offer>
    {
        
        Task<IEnumerable<OfferDDlLViewModels>> GetDDL();
    }
}
