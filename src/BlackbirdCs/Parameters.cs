using BlackbirdCs.Entities;
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

        public Parameters(string configFileName)
        {
            if (!File.Exists(configFileName))
            {
                throw new FileNotFoundException("Configuration file not found!", configFileName);
            }


        }
    }
}
