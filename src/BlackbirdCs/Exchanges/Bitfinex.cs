using BlackbirdCs.Entities;
using BlackbirdCs.Interfaces;
using Refit;
using System.Threading.Tasks;

namespace BlackbirdCs.Exchanges
{
    internal class Bitfinex : IExchange
    {
        private const string _bitstampMainUrl = "https://www.bitstamp.net";

        public async Task<Ticker> GetQuote(string currencyPair)
        {
            var bitstampApi = RestService.For<IBitstampApi>(_bitstampMainUrl);
            var bsTicker = await bitstampApi.GetTicker(currencyPair);
            var ticker = new Ticker
            {
                Last = bsTicker.Last,
                High = bsTicker.High,
                Low = bsTicker.Low
            };

            return ticker;
        }
    }
}
