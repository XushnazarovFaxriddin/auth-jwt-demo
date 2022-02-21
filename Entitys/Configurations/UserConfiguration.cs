using Entitys.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = new Guid("7f1d0162-c5fd-457f-8071-8bc801fb260d"),
                    FirstName = "Admin",
                    LastName = "Boss",
                    Login = "admin",
                    Password = "admin",
                    IsDeleted = false,
                    Role = RoleEnum.Admin
                },
                new User
                {
                    Id = new Guid("7138e720-0746-4d85-94cc-58c720ce4cf4"),
                    FirstName = "User",
                    LastName = "Employee",
                    Login = "user",
                    Password = "user",
                    IsDeleted = false,
                    Role = RoleEnum.User
                });
        }
    }
}
