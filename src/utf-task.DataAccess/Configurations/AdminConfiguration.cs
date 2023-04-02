using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utf_task.Domain.Entities;

namespace utf_task.DataAccess.Configurations
{
    public class AdminConfiguration:IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasData(new Admin()
            {
                Id = 2,
                Login = "admin",
                PasswordHash = "faaad25c6c1126859d843edf08bbf5eecb24bd09ed2684c6bcc2aa960e0bda00",
                Salt = "AC927qIDIUsM",
                SecretKey = "nothing"
            }) ;
        }
    }
}
