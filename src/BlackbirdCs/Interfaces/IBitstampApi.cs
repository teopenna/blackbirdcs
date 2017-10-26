using BlackbirdCs.Entities;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlackbirdCs.Interfaces
{
    public interface IBitstampApi
    {
        [Get("/api/v2/ticker/{currencyPair}")]
        Task<BitstampTicker> GetTicker(string currencyPair);
    }
}
