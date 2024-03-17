using muchos_motors_api.EntityFramework.Repositories;
using AutoMapper;
using muchos_motors_api.DTOModels;
using muchos_motors_api.EntityFramework;
using muchos_motors_api.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using muchos_motors_api.PaginationHelper;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using muchos_motors_api.Utils;

namespace muchos_motors_api.Services
{
    public class ImageService
    {

        public async Task<string> SaveImageAsync(string base64Image, string folderPath, CancellationToken cancellationToken = default)
        {
            if (!string.IsNullOrEmpty(base64Image))
            {
                byte[]? slika_bajtovi = base64Image.ParseBase64();

                if (slika_bajtovi == null)
                    throw new AppException("Pogresan base64 format");

                byte[]? slika_bajtovi_resized_velika = ImageUtils.ResizeImage(slika_bajtovi, 300);
                if (slika_bajtovi_resized_velika == null)
                    throw new AppException("Pogresan format slike");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var imageUrl = $"{folderPath}/{Guid.NewGuid()}.jpg";

                await System.IO.File.WriteAllBytesAsync(imageUrl, slika_bajtovi_resized_velika, cancellationToken);
                return imageUrl;
            }
            return null;
        }
    }
}