using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using url_encoder.Url;

namespace url_encoder.Database
{
    public class UrlConfig : IEntityTypeConfiguration<Url.Url>
    {
        public void Configure(EntityTypeBuilder<Url.Url> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.OriginalUrl).IsRequired();

            builder.Property(x => x.EncoderUrl).IsRequired();
        }
    }
}
