using BlackbirdCs.Exchanges;

namespace BlackbirdCs.Entities
{
    public class ExchangeConfig
    {
        public string Name { get; set; }
        public string ClientId { get; set; }
        public string ApiKey { get; set; }
        public string SecretKey { get; set; }
        public decimal Fees { get; set; }
        public bool Enabled { get; set; }
        public bool CanShort { get; set; }
        public bool IsImplemented { get; set; }
        public string ExchangeType { get; set; }
    }
}
