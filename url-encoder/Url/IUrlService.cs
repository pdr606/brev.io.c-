namespace url_encoder.Url
{
    public interface IUrlService
    {
        public Task<string> Add(string url);
        public Task<(string? url, bool succes)> FindByCode(string code);
    }
}
