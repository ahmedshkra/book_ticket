using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using تذكرتك_علينا.Models;

namespace تذكرتك_علينا.Data
{
    public class تذكرتك_عليناContext : DbContext
    {
        public تذكرتك_عليناContext (DbContextOptions<تذكرتك_عليناContext> options)
            : base(options)
        {
        }

        public DbSet<تذكرتك_علينا.Models.infomodel> infomodel { get; set; } = default!;
    }
}
