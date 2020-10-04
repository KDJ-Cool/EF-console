using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Royal.Domain
{
    public class Knight
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public RoyalFamily RoyalFamily { get; set; }
        public List<KnightVows> Vows { get; set; }
    }
}
