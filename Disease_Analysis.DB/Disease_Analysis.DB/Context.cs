using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disease_Analysis.DB
{
    public class Context : DbContext
    {
        public DbSet<Disease> Disease { get; set; }

        public Context() : base("localsql")
        {

        }
    }
}
