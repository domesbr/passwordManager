using PasswordManager.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PasswordManager.Entities
{
    [Table("User")]
    public class User
    {
        public User(int id, string password, string email, DateTime created)
        {
            Id = id;
            Password = password;
            EMail = email;
            Created = created;
            loginDatas = new List<LoginData>();
        }

        [Column("id")]
        public int Id { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("email")]
        public string EMail{ get; set; }

        [Column("created")]
        public DateTime Created { get; set; }

        public List<LoginData> loginDatas { get; set; }
    }
}
