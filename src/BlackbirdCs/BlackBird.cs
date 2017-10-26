using BlackbirdCs.Entities;
using BlackbirdCs.Interfaces;
using Refit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BlackbirdCs
{
    internal class BlackBird
    {
        private List<ExchangeConfig> _enabledExchanges;

        internal void Run(string configFileName)
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

            _enabledExchanges = new List<ExchangeConfig>();

            foreach (var exchangeConfig in parameters.ExchangesConfig)
            {
                if (exchangeConfig.Enabled && (!string.IsNullOrEmpty(exchangeConfig.ApiKey) || parameters.DemoMode))
                {
                    var exchangeType = Type.GetType(exchangeConfig.ExchangeType);
                }
            }
        }
    }
}
