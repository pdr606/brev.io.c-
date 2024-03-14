using url_encoder.Url;

namespace url_encoder.Database
{
    public interface IUrlRepository
    {
        public Task Add(Url.Url url);
        public Task<Url.Url> FindByCode(string code);
    }
}
