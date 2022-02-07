using Arvind.Contract;
using Arvind.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arvind.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AppDbContext context;
        private IInstituteRepository institute;
        private IEmployeeRepository employee;
        public RepositoryWrapper(AppDbContext context)
        {
            this.context = context;
        } 
        public void Save()
        {
            context.SaveChanges();
        }
        public IInstituteRepository Institute
        {
            get
            {
                if(institute == null)
                {
                    institute = new InstituteRepository(context);
                }
                return institute;
            }
        }

        public IEmployeeRepository Employee
        {
            get
            {
                if (employee == null)
                {
                    employee = new EmployeeRepository(context);
                }
                return employee;
            }
        }
    }
}
