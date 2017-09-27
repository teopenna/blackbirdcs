using BlackbirdCs.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BlackbirdCs
{
    internal class Parameters
    {
        public bool DemoMode { get; set; }
        public List<Exchange> Exchanges { get; set; }
        public decimal SpreadEntry { get; set; }
        public decimal SpreadTarget { get; set; }
        public uint MaxLength { get; set; }
        public decimal PriceDeltaLim { get; set; }
        public decimal TrailingLim { get; set; }
        public uint TrailingCount { get; set; }
        public string Leg1 { get; set; }
        public string Leg2 { get; set; }

        private Parameters()
        {
        }

        public static Parameters CreateParametersFromJsonFile(string jsonFileName)
        {
            if (!File.Exists(jsonFileName))
            {
                throw new FileNotFoundException("Configuration file not found!", jsonFileName);
            }

            var parameters = new Parameters();

            using (JsonTextReader reader = new JsonTextReader(File.OpenText(jsonFileName)))
            {
                var serializer = new JsonSerializer();
                parameters = serializer.Deserialize<Parameters>(reader);
            }

            return parameters;
        }
    }
}
