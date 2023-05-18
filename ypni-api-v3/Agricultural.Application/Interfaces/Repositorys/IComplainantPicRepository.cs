using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ComplainantPic;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IComplainantPicRepository: IGenericRepository<ComplainantPic>
    {
        
        Task<IEnumerable<ComplainantPicDDlLViewModels>> GetDDL();
    }
}
