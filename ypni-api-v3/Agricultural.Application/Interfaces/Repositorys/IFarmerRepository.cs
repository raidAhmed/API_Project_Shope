using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Farmer;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IFarmerRepository: IGenericRepository<Farmer>
    {

        Task<IEnumerable<FarmerDDlLViewModels>> GetDDL();
    }
}
