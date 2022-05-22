using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanWeFixIt.Service.Shared.Interfaces
{
    public interface IMarketDataService
    {
        Task<List<MarketDataDto>> GetMarketDataList();
        Task<List<MarketValuationDto>> GetMarketValuation();
    }
}
