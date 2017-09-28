namespace BlackbirdCs.Entities
{
    internal class Exchange
    {
        public string Name { get; set; }
        public string ClientId { get; set; }
        public string ApiKey { get; set; }
        public string SecretKey { get; set; }
        public decimal Fees { get; set; }
        public bool Enabled { get; set; }
        //public bool CanShort { get; set; }
        //public bool IsImplemented { get; set; }
        //public string TickerUrl { get; set; }
    }
}
