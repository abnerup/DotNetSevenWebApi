
namespace DotNetSevenWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=localhost\\sqlexpress;DataBase=SuperHeroDB;Trusted_Connection=True;TrustServerCertificate=true;");
        }
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
