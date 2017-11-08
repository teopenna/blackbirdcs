using BlackbirdCs.Entities;
using BlackbirdCs.Exchanges;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlackbirdCs
{
    public class BlackBird
    {
        private List<IExchange> _enabledExchanges;
        private CancellationTokenSource _quotesCancellationTokenSource;
        private CancellationToken _quotesCancellationToken;

        public BlackBird()
        {
            _quotesCancellationTokenSource = new CancellationTokenSource();
            _quotesCancellationToken = _quotesCancellationTokenSource.Token;
        }

        internal void CancelRun()
        {
            _quotesCancellationTokenSource.Cancel();
        }

        internal async Task Run(string configFileName)
        {
            Console.WriteLine("Blackbird Bitcoin Arbitrage");
            Console.WriteLine("DISCLAIMER: USE THE SOFTWARE AT YOUR OWN RISK");

            // Load Parameters
            var parameters = Parameters.CreateParametersFromJsonFile(configFileName);

            if (!parameters.DemoMode)
            {
                if (!parameters.UseFullExposure)
                {
                    if (parameters.TestedExposure < 10 && parameters.Leg2 == "USD")
                    {
                        Console.WriteLine("ERROR: Minimum USD needed: 10$");
                        Console.WriteLine("    Otherwise some exchanges will reject the orders");
                        return;
                    }
                    if (parameters.TestedExposure > parameters.MaxExposure)
                    {
                        Console.WriteLine($"ERROR: Test exposure ({parameters.TestedExposure}) is above max exposure ({parameters.MaxExposure})");
                        return;
                    }
                }
            }

            // TODO: Db connection

            if (parameters.Leg1 != "BTC" || parameters.Leg2 != "USD")
            {
                Console.WriteLine("ERROR: Valid currency pair is only BTC/USD for now.");
                return;
            }

            _enabledExchanges = new List<IExchange>();

            foreach (var exchangeConfig in parameters.ExchangesConfig)
            {
                if (exchangeConfig.Enabled && (!string.IsNullOrEmpty(exchangeConfig.ApiKey) || parameters.DemoMode))
                {
                    var exchangeType = Type.GetType(exchangeConfig.ExchangeType, true, true);

                    _enabledExchanges.Add((IExchange)Activator.CreateInstance(exchangeType));
                }
            }

            await PeriodicTask<List<IExchange>>.Run(GetExchangeQuotes, _enabledExchanges, new TimeSpan(0, 0, 3), _quotesCancellationToken);
        }

        private async void GetExchangeQuotes(List<IExchange> exchanges)
        {
            List<Task<Ticker>> tasks = new List<Task<Ticker>>();

            foreach (IExchange exchange in exchanges)
            {
                tasks.Add(Task<Ticker>.Run(() => GetQuote(exchange, "btcusd")));
            }

            await Task.WhenAll(tasks);

            tasks.ForEach(t => Console.WriteLine($"{DateTime.Now.ToString("yyyyMMdd hh:mm:ss.fff")} - Last: {t.Result.Last}"));
        }

        private async Task<Ticker> GetQuote(IExchange exchange, string currencyPair)
        {
            var ticker = await exchange.GetQuote(currencyPair);

            return ticker;
        }
    }
}
