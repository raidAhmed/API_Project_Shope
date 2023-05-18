using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.Product_Variant_Attribute;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IProduct_Variant_AttributeRepository: IGenericRepository<Product_Variant_Attribute>
    {
       
        Task<IEnumerable<Product_Variant_AttributeDDlLViewModels>> GetDDL();
    }
}
