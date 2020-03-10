using PasswordManager.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PasswordManager.Database.Entities
{
    [Table("login_data")]
    class LoginData
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("username")]
        public string username { get; set; }

        [Column("password")]
        public string password { get; set; }

        [Column("link")]
        public string link { get; set; }

        [Column("user_id")]
        public int userId { get; set; }
        public User user { get; set; }
    }
}
