using System.ComponentModel.DataAnnotations;

namespace url_encoder.Url
{
    public class Url
    {
        public long Id { get; private set; }
        public string OriginalUrl { get; private set; } = string.Empty;
        public string EncoderUrl { get; private set; }  = string.Empty;
        public DateTime ExpiredDate { get; private set; }

        public Url() { }

        public Url(string originalUrl, string encodeUrl, DateTime expiredDate)
        {
            OriginalUrl = originalUrl;
            EncoderUrl = encodeUrl;
            ExpiredDate = expiredDate;
        }
    }
}
