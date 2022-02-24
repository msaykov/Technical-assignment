namespace OffersDb.Models
{
    using Microsoft.EntityFrameworkCore;

    public class OffersDbContext : DbContext
    {
        public DbSet<Offer> Offers { get; set; }

        //protected override void OnConfiguring()

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Offers;Integrated Security=true");
        }
    }
}
