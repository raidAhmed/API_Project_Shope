using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ServicesType;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IServicesTypeRepository : IGenericRepository<ServicesType>
    {
       
        Task<IEnumerable<ServicesTypeDDlLViewModels>> GetDDL();
    }
}
