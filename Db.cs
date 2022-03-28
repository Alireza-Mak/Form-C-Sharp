using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    using System.Data.Entity;
    public class Db:DbContext
    {
        public Db() : base("rt")
        {
        }
        public DbSet <Student> students { get; set; }
    }
}
