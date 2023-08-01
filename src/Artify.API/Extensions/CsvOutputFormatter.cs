using Artify.Entities.DTO;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace Artify.API.Extensions
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type? type)
        {
            if (typeof(ArtworkDto).IsAssignableFrom(type) ||
           typeof(IEnumerable<ArtworkDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext
context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();
            if (context.Object is IEnumerable<ArtworkDto>)
            {
                foreach (var artwork in (IEnumerable<ArtworkDto>)context.Object)
                {
                    FormatCsv(buffer, artwork);
                }
            }
            else
            {
                FormatCsv(buffer, (ArtworkDto)context.Object);
            }
            await response.WriteAsync(buffer.ToString());
        }

        private static void FormatCsv(StringBuilder buffer, ArtworkDto artwork)
        {
            buffer.AppendLine($"{artwork.Id},\"{artwork.Title},\"{artwork.Description}\"{artwork.ImageUrl}\"");
        }
    }
}
