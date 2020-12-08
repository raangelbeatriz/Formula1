using Microsoft.EntityFrameworkCore;
using Formula1.Models;

namespace Formula1.Data
{
    public class Formula1Context : DbContext
    {
        public Formula1Context (DbContextOptions<Formula1Context> options)
            : base(options)
        {
        }

        public DbSet<Posicao> Posicao { get; set; }
    }
}
