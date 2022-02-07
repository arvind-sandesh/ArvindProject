using Arvind.Contract;
using Arvind.Entities;
using Arvind.Entities.Model;
using Arvind.Entities.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arvind.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee, AppDbContext>, IEmployeeRepository
    {
        private readonly AppDbContext context;        
        public EmployeeRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }       

        public void CreateUser(UserCreateVM model)
        {
            if (model != null)
            {               
                    Employee emp = new Employee
                    {
                        DateOfBirth = model.DateOfBirth,
                        Email = model.Email,
                        EmployeeName = model.EmployeeName.ToUpper(),
                        Gender = model.Gender,
                        InstituteId = model.InstituteId
                    };
                    Create(emp); //base mathod for add.                
            }            
        }

        public List<Employee> UserListOfInstitute(long id)
        {
             return  FindByCondition(x => x.InstituteId.Equals(id)).ToList();           
        }
    }
}
