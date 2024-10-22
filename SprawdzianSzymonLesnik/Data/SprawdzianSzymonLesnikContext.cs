using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SprawdzianSzymonLesnik.Models;

namespace SprawdzianSzymonLesnik.Data
{
    public class SprawdzianSzymonLesnikContext : DbContext
    {
        public SprawdzianSzymonLesnikContext (DbContextOptions<SprawdzianSzymonLesnikContext> options)
            : base(options)
        {
        }

        public DbSet<SprawdzianSzymonLesnik.Models.Uczen> Uczen { get; set; } = default!;
        public DbSet<SprawdzianSzymonLesnik.Models.Nauczyciel> Nauczyciel { get; set; } = default!;
        public DbSet<SprawdzianSzymonLesnik.Models.Kurs> Kurs { get; set; } = default!;
    }
}
