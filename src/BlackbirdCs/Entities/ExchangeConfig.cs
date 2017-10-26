using BlackbirdCs.Exchanges;

namespace BlackbirdCs.Entities
{
    internal class ExchangeConfig
    {
        internal string Name { get; set; }
        internal string ClientId { get; set; }
        internal string ApiKey { get; set; }
        internal string SecretKey { get; set; }
        internal decimal Fees { get; set; }
        internal bool Enabled { get; set; }
        internal bool CanShort { get; set; }
        internal bool IsImplemented { get; set; }
        internal string ExchangeType { get; set; }
    }
}
