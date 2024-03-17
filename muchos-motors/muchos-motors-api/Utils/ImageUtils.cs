
using SkiaSharp;
using System.IO;

namespace muchos_motors_api.Utils
{
    public static class ImageUtils
    {

        public static byte[] ParseBase64(this string base64string)
        {
            base64string = base64string.Split(',')[1];
            return System.Convert.FromBase64String(base64string);
        }

        public static byte[]? ResizeImage(byte[] imageBytes, int size, int quality = 75)
        {
            using var input = new MemoryStream(imageBytes);
            using var inputStream = new SKManagedStream(input);
            using var original = SKBitmap.Decode(inputStream);
            int width, height;
            if (original.Width > original.Height)
            {
                width = size;
                height = original.Height * size / original.Width;
            }
            else
            {
                width = original.Width * size / original.Height;
                height = size;
            }

            using var resized = original
                .Resize(new SKImageInfo(width, height), SKBitmapResizeMethod.Lanczos3);

            if (resized == null) return null;

            using var image = SKImage.FromBitmap(resized);
            return image.Encode(SKEncodedImageFormat.Jpeg, quality)
                .ToArray();
        }

    }
}

