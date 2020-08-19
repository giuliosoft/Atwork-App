using System;
using System.Collections.Generic;
using System.Text;

namespace Atwork.Models
{
    public class Login
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string Token { get; set; }
        public string SetupComplete { get; set; }
        public string CompanyId { get; set; }
    }
}
