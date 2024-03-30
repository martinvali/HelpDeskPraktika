using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AgileWorks.Models;

namespace AgileWorks.Data
{
    public class TicketDatabaseContext : DbContext
    {
        public TicketDatabaseContext (DbContextOptions<TicketDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<AgileWorks.Models.Ticket> Ticket { get; set; } = default!;
    }
}
