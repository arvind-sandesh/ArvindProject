using Arvind.Contract;
using Arvind.Entities;
using Arvind.Entities.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arvind.Repository
{
    public class InstituteRepository:RepositoryBase<Institute,AppDbContext>, IInstituteRepository
    {
        private readonly AppDbContext context;

        public InstituteRepository(AppDbContext context):base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Institute>> GetAllInstituteAsync()
        {
            return await FindAll().OrderBy(x => x.InstituteName).ToListAsync();
        }

        public async Task<Institute> GetInstituteByIdAsync(long id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<Institute> GetInstituteWithDetailAsync(long id)
        {
            return await FindByCondition(x => x.Id.Equals(id))
                .Include(x=>x.Employees)
                .FirstOrDefaultAsync();
        }
    }
}
