using PasswordManager.Entities;
using ServiceStack;
using System.ComponentModel.DataAnnotations.Schema;

namespace PasswordManager.Database.Entities
{
    [Route("/test")]
    [Table("login_data")]
    public class LoginData
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
