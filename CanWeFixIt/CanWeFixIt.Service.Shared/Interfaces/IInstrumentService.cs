using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanWeFixIt.Service.Shared.Interfaces
{
    public interface IInstrumentService
    {
        Task<List<InstrumentDto>> GetInstrumentList();
    }
}
