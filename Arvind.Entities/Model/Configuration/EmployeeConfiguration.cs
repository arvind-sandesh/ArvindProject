using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arvind.Entities.Model.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //builder.HasData(
            //    new Employee
            //    {
            //        Id = 1,
            //        DateOfBirth = new DateTime(1984, 7, 10),
            //        Email = "arvind.monu@gmail.com",
            //        EmployeeName = "Arvind Kumar",
            //        Gender = "Male",
            //        InstituteId = 1
            //    }
            //);
        }
    }
}
