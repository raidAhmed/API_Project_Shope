using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.ManufactureCompany;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface IManufactureCompanyRepository: IGenericRepository<ManufactureCompany>
    {
        Task<IEnumerable<ManufactureCompanyDDlLViewModels>> GetDDL();
    }
}
