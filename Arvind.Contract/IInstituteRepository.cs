using Arvind.Entities.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arvind.Contract
{
    public interface IInstituteRepository : IRepositoryBase<Institute>
    {
        Task<IEnumerable<Institute>> GetAllInstituteAsync();
        Task<Institute> GetInstituteByIdAsync(long id);
        Task<Institute> GetInstituteWithDetailAsync(long id);
        
    }
}
