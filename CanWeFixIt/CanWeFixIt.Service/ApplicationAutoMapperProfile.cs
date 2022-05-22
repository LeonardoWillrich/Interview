using AutoMapper;
using CanWeFixIt.Domain.Entitites;
using CanWeFixIt.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanWeFixIt.Service
{
    public class ApplicationAutoMapperProfile : Profile
    {
        public ApplicationAutoMapperProfile()
        {
            CreateMap<Instrument, InstrumentDto>();
        }
    }
}
