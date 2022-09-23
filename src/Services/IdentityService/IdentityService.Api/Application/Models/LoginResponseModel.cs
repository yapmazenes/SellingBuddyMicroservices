using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Api.Application.Models
{
    public class LoginResponseModel
    {
        public string UserName { get; set; }
        public string UserToken { get; set; }
    }
}
