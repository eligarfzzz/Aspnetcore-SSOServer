using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameWork.WebAPI.Models
{
    public class IsLoginResult
    {
        public bool IsLogin { get; set; }
        public string token { get; set; }
    }
}
