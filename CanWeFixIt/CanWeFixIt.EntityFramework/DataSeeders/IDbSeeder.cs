using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanWeFixIt.EntityFramework.DataSeeders
{
    public interface IDbSeeder
    {
        Task ExecuteSeeder();
    }
}
