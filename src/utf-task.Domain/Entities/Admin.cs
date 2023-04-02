using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utf_task.Domain.Common;

namespace utf_task.Domain.Entities
{
    public class Admin:BaseEntity
    {
        public string Login { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public string SecretKey { get; set; } = string.Empty;
    }
}
