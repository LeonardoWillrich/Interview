using AutoMapper;
using CanWeFixIt.EntityFramework;
using CanWeFixIt.Service.Shared;
using CanWeFixIt.Service.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanWeFixIt.Service.Services
{
    public class MarketDataService : IMarketDataService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public MarketDataService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<MarketDataDto>> GetMarketDataList()
        {
            var output = await _dbContext.MarketsData.Where(x => x.Active)
                .Join(_dbContext.Instruments, marketData => marketData.Sedol, instrument => instrument.Sedol, (marketData, instrument) => new MarketDataDto()
                {
                    Id = marketData.Id,
                    DataValue = marketData.DataValue,
                    Active = marketData.Active,
                    InstrumentId = instrument.Id
                }).ToListAsync();
            return output;
        }

        public async Task<List<MarketValuationDto>> GetMarketValuation()
        {
            var total = await _dbContext.MarketsData.Where(x => x.Active).SumAsync(x => x.DataValue);
            var output = new List<MarketValuationDto>()
            {
                new MarketValuationDto()
                {
                    Name = "DataValueTotal",
                    Total = total.GetValueOrDefault()
                }
            };
            return output;
        }
    }
}
