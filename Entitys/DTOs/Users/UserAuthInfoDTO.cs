using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.DTOs.Users
{
    public class UserAuthInfoDTO
    {
        public UserDTO UserDetails { get; set; }
        public string Token { get; set; }
    }
}
