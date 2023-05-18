using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product_Image;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IProduct_ImageRepository: IGenericRepository<Product_Image>
    {
        
        Task<IEnumerable<Product_ImageDDlLViewModels>> GetDDL();
    }
}
