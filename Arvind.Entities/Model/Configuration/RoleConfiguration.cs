﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arvind.Entities.Model.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole
            {
                Name = "Staff",
                NormalizedName = "STAFF"
            },
            new IdentityRole
            {
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN"
            },
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            }
            );
        }
    }
}
