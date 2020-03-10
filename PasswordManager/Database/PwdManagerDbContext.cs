using MySql.Data.Entity;
using PasswordManager.Database.Entities;
using PasswordManager.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Database
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    class PwdManagerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<LoginData> LoginDatas { get; set; }

        public PwdManagerDbContext()
          : base()
        {

        }

        // Constructor to use on a DbConnection that is already opened
        public PwdManagerDbContext(DbConnection existingConnection, bool contextOwnsConnection)
          : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
