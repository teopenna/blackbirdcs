namespace BlackbirdCs.Entities
{
    internal class Exchange
    {
        public string Name { get; set; }
        public decimal Fee { get; set; }
        public bool CanShort { get; set; }
        public bool IsImplemented { get; set; }
        public string TickerUrl { get; set; }
    }
}
