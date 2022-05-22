using CanWeFixIt.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanWeFixIt.EntityFramework.DataSeeders
{
    public class CanWeFixItDbSeeder : IDbSeeder
    {

        private readonly ApplicationDbContext _dbContext;

        public CanWeFixItDbSeeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private List<Instrument> _instruments = new() {
            new Instrument()
            {
                Id = 1,
                Sedol = "Sedol1",
                Name = "Name1",
                Active = false
            },
            new Instrument()
            {
                Id = 2,
                Sedol = "Sedol2",
                Name = "Name2",
                Active = true
            },
            new Instrument()
            {
                Id = 3,
                Sedol = "Sedol3",
                Name = "Name3",
                Active = false
            },
            new Instrument()
            {
                Id = 4,
                Sedol = "Sedol4",
                Name = "Name4",
                Active = true
            },
            new Instrument()
            {
                Id = 5,
                Sedol = "Sedol5",
                Name = "Name5",
                Active = false
            },
            new Instrument()
            {
                Id = 6,
                Sedol = "",
                Name = "Name6",
                Active = true
            },
            new Instrument()
            {
                Id = 7,
                Sedol = "Sedol7",
                Name = "Name7",
                Active = false
            },
            new Instrument()
            {
                Id = 8,
                Sedol = "Sedol8",
                Name = "Name8",
                Active = true
            },
            new Instrument()
            {
                Id = 9,
                Sedol = "Sedol9",
                Name = "Name9",
                Active = false
            },
        };

        private List<MarketData> _marketsData = new()
        {
            new MarketData()
            {
                Id = 1,
                DataValue = 1111,
                Sedol = "Sedol1",
                Active = false,
            },
            new MarketData()
            {
                Id = 2,
                DataValue = 2222,
                Sedol = "Sedol2",
                Active = true,
            },
            new MarketData()
            {
                Id = 3,
                DataValue = 3333,
                Sedol = "Sedol3",
                Active = false,
            },
            new MarketData()
            {
                Id = 4,
                DataValue = 4444,
                Sedol = "Sedol4",
                Active = true,
            },
            new MarketData()
            {
                Id = 5,
                DataValue = 55555,
                Sedol = "Sedol5",
                Active = false,
            },
            new MarketData()
            {
                Id = 6,
                DataValue = 6666,
                Sedol = "Sedol6",
                Active = true,
            },
        };

        private async Task CreateTables()
        {
            const string createInstruments = @"CREATE TABLE Instruments
                (
                    id     int,
                    sedol  text,
                    name   text,
                    active int
                );";
            await _dbContext.Database.ExecuteSqlRawAsync(createInstruments);
            _dbContext.SaveChanges();

            //using var viewCommand = _dbContext.Database.GetDbConnection().CreateCommand();
            //viewCommand.CommandText = createInstruments;
            //viewCommand.ExecuteNonQuery();

            const string createMarketData = @"
                CREATE TABLE MarketsData
                (
                    id        int,
                    datavalue int,
                    sedol     text,
                    active    int
                );";
            await _dbContext.Database.ExecuteSqlRawAsync(createMarketData);
            _dbContext.SaveChanges();
        }

        public async Task ExecuteSeeder()
        {
            try
            {
                await CreateTables();
                await _dbContext.Instruments.AddRangeAsync(_instruments);
                await _dbContext.MarketsData.AddRangeAsync(_marketsData);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error DataSeeder: {0}", ex.Message);
            }
            Console.WriteLine("Database Seeder completed");
        }
    }
}
