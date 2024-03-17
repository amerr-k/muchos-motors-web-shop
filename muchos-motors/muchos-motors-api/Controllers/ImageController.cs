using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using muchos_motors_api.EntityFramework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace muchos_motors_api.Controllers
{
    [Route("api/images")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private DataDbContext context;
        private static string CAR_PART_DEFAULT_FOLDER_PATH;
        private readonly IConfiguration configuration;
        
        public ImageController(DataDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
            if (CAR_PART_DEFAULT_FOLDER_PATH == null)
            {
                CAR_PART_DEFAULT_FOLDER_PATH = this.configuration["DefaultImagePath"];
            }
        }

        [HttpGet("car-part")]
        public async Task<FileContentResult> GetCarPartImage(int carPartId, CancellationToken cancellationToken)
        {

            var carPart = await context.CarPart.FindAsync(carPartId);

            if (carPart  != null)
            {
                byte[] slika;
                try
                {
                    var fileName = carPart.ImageUrl;
                    slika = await System.IO.File.ReadAllBytesAsync(fileName, cancellationToken);
                    return File(slika, GetMimeType(fileName));
                }
                catch (Exception ex)
                {
                    var fileName = CAR_PART_DEFAULT_FOLDER_PATH;
                    slika = await System.IO.File.ReadAllBytesAsync(fileName, cancellationToken);
                    return File(slika, GetMimeType(fileName));
                }
            }
            return null;
        }

        static string GetMimeType(string fileName)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (provider.TryGetContentType(fileName, out var contentType))
            {
                return contentType;
            }
            return "application/octet-stream";
        }
    }
}

