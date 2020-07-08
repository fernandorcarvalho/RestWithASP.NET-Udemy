using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace RestWithASP.NETUdemy.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext ()
        {

        }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {

        }

        public DbSet<Controllers.Model.Person> Persons { get; set; } 

    }
}
