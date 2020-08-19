using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Atwork.DTO
{
    public class LoginDTO
    {
        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
                
        [JsonProperty("newpassword")]
        public string NewPassword { get; set; }
    }
}
