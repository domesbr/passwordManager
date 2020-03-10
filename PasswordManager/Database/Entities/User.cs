using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Entities
{
    [Table("User")]
    class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string EMail{ get; set; }
        public DateTime Created { get; set; }
    }
}
