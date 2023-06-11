using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class ImgurService
{
    private readonly HttpClient _httpClient;

    public ImgurService()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Client-ID", "YOUR_CLIENT_ID");
    }

    public async Task<List<string>> UploadImagesAsync(IFormFileCollection imageFiles)
    {
        var imageUrls = new List<string>();

        foreach (var imageFile in imageFiles)
        {
            using (var stream = imageFile.OpenReadStream())
            {
                byte[] imageData;
                using (var memoryStream = new MemoryStream())
                {
                    await stream.CopyToAsync(memoryStream);
                    imageData = memoryStream.ToArray();
                }

                var content = new MultipartFormDataContent();
                var imageContent = new ByteArrayContent(imageData);
                imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");

                content.Add(imageContent, "image");

                var response = await _httpClient.PostAsync("https://api.imgur.com/3/image", content);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var parsedResponse = JsonDocument.Parse(responseContent);
                var imageUrl = parsedResponse.RootElement.GetProperty("data").GetProperty("link").GetString();

                imageUrls.Add(imageUrl);
            }
        }

        return imageUrls;
    }
}
