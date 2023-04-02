using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utf_task.DataAccess.Interfaces.Common;
using utf_task.Domain.Entities;
using utf_task.Service.Common.Exceptions;
using utf_task.Service.Common.Security;
using utf_task.Service.Interfaces.Main;
using utf_task.Service.Interfaces.Security;

namespace utf_task.Service.Services
{
    public class AdminService:IAdminService
    {
        private readonly IUnitOfWork _work;
        private readonly IAuthService _auth;

        public AdminService(IUnitOfWork work, IAuthService auth)
        {
            _work = work;
            _auth = auth;
        }

        public async Task<string> VerifyAdmin(string login, string password)
        {
            var admin = await _work.Admins.FirstOrDefaultAsync(x => x.Login == login);
            if (admin != null && PasswordService.Verify(password, admin.Salt, admin.PasswordHash))
                return _auth.GenerateToken(admin);
            throw new StatusCodeException(System.Net.HttpStatusCode.NotFound, "Login or Password wrong.Try again");
        }
    }
}
