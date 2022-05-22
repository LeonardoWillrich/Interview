using System.Collections.Generic;
using System.Threading.Tasks;
using CanWeFixIt.Service.Shared;
using CanWeFixIt.Service.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CanWeFixItApi.Controllers
{
    [ApiController]
    [Route("v1")]
    public class MarketDataController : ControllerBase
    {
        private readonly IMarketDataService _marketDataService;

        public MarketDataController(IMarketDataService marketDataService)
        {
            _marketDataService = marketDataService;
        }

        [HttpGet("marketdata")]
        public async Task<ActionResult<IEnumerable<MarketDataDto>>> Get()
        {
            return await _marketDataService.GetMarketDataList();
        }

        [HttpGet("valuations")]
        public async Task<ActionResult<IEnumerable<MarketValuationDto>>> GetMarketValuation()
        {
            return await _marketDataService.GetMarketValuation();
        }
    }
}