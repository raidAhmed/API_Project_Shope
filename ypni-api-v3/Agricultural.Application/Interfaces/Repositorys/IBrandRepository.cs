using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Brand;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IBrandRepository: IGenericRepository<Brand>
    {
  
        Task<IEnumerable<BrandDDlLViewModels>> GetDDL();
    }
}
