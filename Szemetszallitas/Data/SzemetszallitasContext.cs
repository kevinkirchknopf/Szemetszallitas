using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Szemetszallitas.Models;

namespace Szemetszallitas.Data
{
    public class SzemetszallitasContext : DbContext
    {
        public SzemetszallitasContext (DbContextOptions<SzemetszallitasContext> options)
            : base(options)
        {
        }

        public DbSet<Szemetszallitas.Models.Szolgaltatas> Szolgaltatas { get; set; } = default!;
        public DbSet<Szemetszallitas.Models.Lakig> Lakig { get; set; } = default!;
        public DbSet<Szemetszallitas.Models.Naptar> Naptar { get; set; } = default!;
    }
}
