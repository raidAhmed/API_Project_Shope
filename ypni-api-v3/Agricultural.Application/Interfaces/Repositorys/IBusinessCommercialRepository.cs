using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.BusinessCommercial;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IBusinessCommercialRepository: IGenericRepository<BusinessCommercial>
    {
        Task<IEnumerable<BusinessCommercialDDlLViewModels>> GetDDL();
    }
}
