using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Models.Users
{
    public class User
    {
        [Column("UserId")]
        public Guid Id { get; set; }

        [Required, MaxLength(30)]
        public string FirstName { get; set; }

        [Required, MaxLength(30)]
        public string LastName { get; set; }

        [Required, MinLength(3), MaxLength(16)]
        public string Login { get; set; }

        [Required, MinLength(4), MaxLength(16)]
        public string Password { get; set; }

        public string Token { get; set; }

        public bool IsDeleted { get; set; }

        public RoleEnum Role { get; set; }
    }
}
