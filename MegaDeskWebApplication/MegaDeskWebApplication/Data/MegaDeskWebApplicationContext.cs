using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MegaDeskWebApplication.Models
{
    public class MegaDeskWebApplicationContext : DbContext
    {
        public MegaDeskWebApplicationContext (DbContextOptions<MegaDeskWebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDeskWebApplication.Models.Quote> Quote { get; set; }
    }
}
