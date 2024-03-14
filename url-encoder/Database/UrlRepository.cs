using Microsoft.EntityFrameworkCore;
using url_encoder.Url;

namespace url_encoder.Database
{
    public class UrlRepository : IUrlRepository
    {
        private readonly ApplicationDbContext _db;

        public UrlRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Add(Url.Url url)
        {
            await _db.Set<Url.Url>().AddAsync(url);
            await _db.SaveChangesAsync();
        }

        public async Task<Url.Url> FindByCode(string code)
        {
            return await _db.Set<Url.Url>().AsNoTracking().FirstOrDefaultAsync(x => x.EncoderUrl == code);
        }
    }
}
