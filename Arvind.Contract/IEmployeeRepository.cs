using Arvind.Entities.Model;
using Arvind.Entities.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arvind.Contract
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        void CreateUser(UserCreateVM model);
        List<Employee> UserListOfInstitute(long id);
    }
}
