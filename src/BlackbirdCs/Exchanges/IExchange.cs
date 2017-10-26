using BlackbirdCs.Entities;
using System.Threading.Tasks;

namespace BlackbirdCs.Exchanges
{
    internal interface IExchange
    {
        Task<Ticker> GetQuote(string currencyPair);
    }
}
