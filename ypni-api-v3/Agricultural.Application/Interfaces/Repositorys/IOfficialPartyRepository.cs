using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.OfficialParty;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IOfficialPartyRepository: IGenericRepository<OfficialParty>
    {
        
        Task<IEnumerable<OfficialPartyDDlLViewModels>> GetDDL();
    }
}
