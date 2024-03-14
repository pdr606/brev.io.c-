using Microsoft.EntityFrameworkCore;
using url_encoder.Url;

namespace url_encoder.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Url.Url> Urls {get; set;}
    }
}
