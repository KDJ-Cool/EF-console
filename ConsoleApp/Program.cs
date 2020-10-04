using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Royal.Data;
using Royal.Domain;

namespace Royal.App
{
    class Program
    {
        private static RoyalContext _context = new RoyalContext();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            _context.Database.EnsureCreated();

            var myKnights = _context.Knights.ToList();
            Console.WriteLine($"Count: {myKnights.Count}");


            var myKnight = AddKnight();

            // LINQ example
            var result = _context.Knights.Where(knight => knight.Name.Length > 5);

            // Data Loading Types >> https://docs.microsoft.com/pl-pl/ef/core/querying/related-data/
            var knights = _context.Knights.Include(k => k.RoyalFamily).ToList();
            Console.WriteLine(knights[0].RoyalFamily);
            
            knights[1].Name = "Tonny";
            _context.SaveChanges();
        }

        private static Knight AddKnight()
        {
            var firstVow = new Vow() {Name = "Vow11", StartDate = new DateTime()};
            var secondVow = new Vow() {Name = "Vow21", StartDate = new DateTime()};

            var royalFamily = new RoyalFamily() {Name = "Hohntzoler2"};

            var knight = new Knight()
                {Name = "Benn2", RoyalFamily = royalFamily, Vows = new List<KnightVows>() {new KnightVows() {Vow = firstVow}, new KnightVows() {Vow = secondVow}}};

            return knight;
        }
    }
}
