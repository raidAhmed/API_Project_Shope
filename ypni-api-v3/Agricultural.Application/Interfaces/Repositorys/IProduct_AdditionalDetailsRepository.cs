using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product_AdditionalDetails;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IProduct_AdditionalDetailsRepository: IGenericRepository<Product_AdditionalDetails>
    {

        Task<IEnumerable<Product_AdditionalDetailsDDlLViewModels>> GetDDL();
    }
}
