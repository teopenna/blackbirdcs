using BlackbirdCs.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlackbirdCs
{
    internal class BlackBird
    {
        private List<Exchange> _enabledExchanges;

        internal void Run(string configFIleName)
        {
            Console.WriteLine("Blackbird Bitcoin Arbitrage");
            Console.WriteLine("DISCLAIMER: USE THE SOFTWARE AT YOUR OWN RISK");

            // Load Parameters
            var parameters = Parameters.CreateParametersFromJsonFile(configFIleName);

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

            _enabledExchanges = new List<Exchange>();

            foreach (var exchange in parameters.Exchanges)
            {
                if (exchange.Enabled && (!string.IsNullOrEmpty(exchange.ApiKey) || parameters.DemoMode))
                {
                    var newExchange = exchange.Clone();
                }
            }
        }
    }
}
