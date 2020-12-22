using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameWork.WebAPI.Models
{
    public class LoginParams
    {
        public string Username { get; set; }
        public string Pwdmd5 { get; set; }
    }
}
