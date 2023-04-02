using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using utf_task.Domain.Entities;

namespace utf_task.Service.Interfaces.Security
{
    public interface IAuthService
    {
        public string GenerateToken(Admin admin);

    }
}
