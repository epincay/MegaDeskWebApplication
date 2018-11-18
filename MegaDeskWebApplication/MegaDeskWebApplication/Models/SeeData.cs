using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MegaDeskWebApplication.Models
{
    public class SeeData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MegaDeskWebApplicationContext(
                serviceProvider.GetRequiredService<DbContextOptions<MegaDeskWebApplicationContext>>()))
            {
                // Look for any quotes.
                if (context.Quote.Any())
                {
                    return;   // DB has been seeded
                }
                context.SaveChanges();
            }
        }
    }
}
