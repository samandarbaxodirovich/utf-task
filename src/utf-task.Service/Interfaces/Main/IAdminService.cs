using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utf_task.Service.Dtos.AdminDto;

namespace utf_task.Service.Interfaces.Main
{
    public interface IAdminService
    {
        public Task<string> VerifyAdmin(string login, string password);
    }
}
