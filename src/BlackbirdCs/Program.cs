using System;
using System.IO;

namespace BlackbirdCs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Blackbird Bitcoin Arbitrage");
            Console.WriteLine("DISCLAIMER: USE THE SOFTWARE AT YOUR OWN RISK");

            // Load Parameters
            var fileName = Path.Combine(AppContext.BaseDirectory, "blackbird.json");
            var parameters = Parameters.CreateParametersFromJsonFile(fileName);

            if (!parameters.DemoMode)
            {
                if (!parameters.UseFullExposure)
                {
                    if (parameters.TestedExposure < 10 && parameters.Leg2 == "USD")
                    {

                    }
                }
            }
        }
    }
}