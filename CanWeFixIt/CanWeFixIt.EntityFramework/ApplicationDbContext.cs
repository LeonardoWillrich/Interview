using CanWeFixIt.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanWeFixIt.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Instrument> Instruments {get; set;}
        public DbSet<MarketData> MarketsData {get; set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            
        }
    }
}
