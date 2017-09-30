namespace BlackbirdCs.Entities
{
    internal class Exchange
    {
        internal string Name { get; set; }
        internal string ClientId { get; set; }
        internal string ApiKey { get; set; }
        internal string SecretKey { get; set; }
        internal decimal Fees { get; set; }
        internal bool Enabled { get; set; }
        internal bool CanShort { get; set; }
        internal bool IsImplemented { get; set; }
        //public string TickerUrl { get; set; }

        internal Exchange Clone()
        {
            var newExchange = new Exchange
            {
                Name = Name,
                ClientId = ClientId,
                ApiKey = ApiKey,
                SecretKey = SecretKey,
                Fees = Fees,
                Enabled = Enabled,
                CanShort = CanShort,
                IsImplemented = IsImplemented
            };

            return newExchange;
        }
    }
}
