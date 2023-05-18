using Agricultural.Application.Interfaces.Common;
using Agricultural.Domain.Entity;
using Agricultural.Application.DTOs.ComplainantToParty;
namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IComplainantToPartyRepository : IGenericRepository<ComplainantToParty>
    {

        Task<IEnumerable<ComplainantToPartyQueryDto>> GetDDL();
    }
}
