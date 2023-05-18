using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Unit;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IUnitRepository: IGenericRepository<Unit>
    {
       
        Task<IEnumerable<UnitDDlLViewModels>> GetDDL();
    }
}
