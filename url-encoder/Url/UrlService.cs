
using System.Text;
using url_encoder.Database;

namespace url_encoder.Url
{
    public class UrlService : IUrlService
    {

        private readonly IUrlRepository _urlRepository;

        public UrlService(IUrlRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }

        public async Task<string> Add(string url)
        {
            var urlEncode = await GenerateCode();

            await _urlRepository.Add(new Url(url, urlEncode, GenerateExpireDate()));

            return urlEncode;
        }

        public async Task<(string? url, bool succes)> FindByCode(string code)
        {
            var entity = await _urlRepository.FindByCode(code);

            return entity != null ? (entity.OriginalUrl, true) : (null, false);
        }

        private async Task<string> GenerateCode()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            StringBuilder code = new StringBuilder();

            var encoderSize = random.Next(5, 10);

            for(var i = 0; i < encoderSize; i++)
            {
                code.Append(chars[random.Next(0, chars.Length)]);
            }

            if(await ExistThisCode(code.ToString()))
            {
                await GenerateCode();
            }

            return code.ToString();
        }

        private DateTime GenerateExpireDate()
        {
            return DateTime.Now.AddMonths(3);
        }

        private async Task<bool> ExistThisCode(string code)
        {
            var entity = await _urlRepository.FindByCode(code);

            return entity != null ? true : false;
        }
    }
}
