using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Color;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IColorRepository: IGenericRepository<Color>
    {
 
        Task<IEnumerable<ColorDDlLViewModels>> GetDDL();
    }
}
