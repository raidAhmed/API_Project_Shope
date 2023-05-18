using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product_Attribute;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IProduct_AttributeRepository: IGenericRepository<Product_Attribute>
    {
        
        Task<IEnumerable<Product_AttributeDDlLViewModels>> GetDDL();
    }
}
