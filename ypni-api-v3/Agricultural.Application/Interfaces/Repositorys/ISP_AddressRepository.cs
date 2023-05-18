using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.SP_Address;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface ISP_AddressRepository: IGenericRepository<SP_Address>
    {
    
        Task<IEnumerable<SP_AddressDDlLViewModels>> GetDDL();
    }
}
