using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ConsultationRequestPic;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IConsultationRequestPicRepository: IGenericRepository<ConsultationRequestPic>
    {
      
        Task<IEnumerable<ConsultationRequestPicDDlLViewModels>> GetDDL();
    }
}
