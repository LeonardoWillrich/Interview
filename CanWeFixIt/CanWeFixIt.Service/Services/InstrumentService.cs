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
    public class InstrumentService : IInstrumentService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public InstrumentService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<InstrumentDto>> GetInstrumentList()
        {
            //var output = await _dbContext.Instruments.Where(x => x.Active).Select(x => new InstrumentDto() { 
            //    Id = x.Id,
            //    Name = x.Name,
            //    Sedol = x.Sedol,
            //    Active = x.Active,
            //}).ToListAsync();
            var output = await _dbContext.Instruments.Where(x => x.Active).Select(x => _mapper.Map<InstrumentDto>(x)).ToListAsync();
            return output;
        }
    }
}
