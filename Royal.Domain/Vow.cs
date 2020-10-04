using System;
using System.Collections.Generic;

namespace Royal.Domain
{
    public class Vow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public List<KnightVows> KnightVows { get; set; }
    }
}