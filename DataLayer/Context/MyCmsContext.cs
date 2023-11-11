using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Mycmscontext:DbContext
    {
        public DbSet<Page> Page { get; set; }
        public DbSet<PageGroup> PageGroup { get; set; }
        public DbSet<PageComment> PageComment { get; set; }
        public DbSet<AdminLogin> AdminLogin { get; set; }
    }
}
