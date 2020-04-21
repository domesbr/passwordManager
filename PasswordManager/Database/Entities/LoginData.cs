using PasswordManager.Entities;
using ServiceStack;
using System.ComponentModel.DataAnnotations.Schema;

namespace PasswordManager.Database.Entities
{
    [Table("login_data")]
    public class LoginData
    {
        public LoginData(int id, string username, string password, string link, int userId, User user)
        {
            Id = id;
            Username = username;
            Password = password;
            Link = link;
            UserId = userId;
            User = user;
        }

        [Column("id")]
        public int Id { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("link")]
        public string Link { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
