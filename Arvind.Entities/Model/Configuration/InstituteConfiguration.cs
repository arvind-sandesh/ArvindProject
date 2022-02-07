using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arvind.Entities.Model.Configuration
{
    public class InstituteConfiguration : IEntityTypeConfiguration<Institute>
    {
        public void Configure(EntityTypeBuilder<Institute> builder)
        {
            builder.HasData(
                new Institute
                {
                    Id = 1,
                    ContactNumber = "9919819824",
                    ContactPerson = "Abhai Srivastava",
                    Email = "abhaideep@gmail.com",
                    InstituteName = "SANDESH TECH SOFT"
                }
            );
        }
    }
}
