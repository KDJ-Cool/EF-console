namespace Royal.Domain
{
    public class KnightVows
    {
        public int KnightId { get; set; }
        public int VowId { get; set; }
        public Knight Knight { get; set; }
        public Vow Vow { get; set; }
    }
}