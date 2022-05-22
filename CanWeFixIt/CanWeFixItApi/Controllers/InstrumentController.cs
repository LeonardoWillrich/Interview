using System.Collections.Generic;
using System.Threading.Tasks;
using CanWeFixIt.Service.Shared;
using CanWeFixIt.Service.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CanWeFixItApi.Controllers
{
    [ApiController]
    [Route("v1")]
    public class InstrumentController : ControllerBase
    {
        private readonly IInstrumentService _instrumentService;

        public InstrumentController(IInstrumentService instrumentService)
        {
            _instrumentService = instrumentService;
        }
        
        [HttpGet("instruments")]
        public async Task<ActionResult<IEnumerable<InstrumentDto>>> GetInstruments()
        {
            return await _instrumentService.GetInstrumentList();
        }
    }
}