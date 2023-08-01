using Artify.WEB.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Headers;

namespace Artify.WEB.Shared
{
    public partial class ImageUpload
    {
        [Parameter]
        public string ImgUrl { get; set; }

        [Parameter]
        public EventCallback<string> OnChange { get; set; }

        [Inject]
        public IArtworkService ArtworkService { get; set; }

        private async Task HandleSelected(InputFileChangeEventArgs e)
        {
            var imageFile = e.File;

            if (imageFile != null)
            {
                using (var ms = imageFile.OpenReadStream(long.MaxValue))
                {
                    var content = new MultipartFormDataContent();
                    content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
                    content.Add(new StreamContent(ms, Convert.ToInt32(imageFile.Size)), "image", imageFile.Name);
                    ImgUrl = await ArtworkService.UploadProductImage(content);
                    await OnChange.InvokeAsync(ImgUrl);
                }
            }
        }
    }
}
