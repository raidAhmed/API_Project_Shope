using Agricultural.Application.Interfaces.Common;
using Agricultural.Application.ViewModels.City;
using Agricultural.Domain.Entity;

namespace Agricultural.Application.Interfaces.Repositorys
{
    public interface ICityRepository : IGenericRepository<City>
    {
        
        Task<IEnumerable<CityDDlLViewModels>> GetDDL();
        //public void ChangeActive(City entity);
    }
}
