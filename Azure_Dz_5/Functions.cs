using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp.Formats.Jpeg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Dz_5
{
    public static class Functions
    {
        public static void ProcessBlobData(
    [BlobTrigger("images/{filename}")] Stream inputFile,
    string filename,
    [Blob("images-min/copy-{filename}", FileAccess.Write)] Stream outputFile,
    ILogger logger
    )
        {
            logger.LogInformation($"C# Blob trigger function processed blob\n Name:{filename}");

            // Load image from stream
            var image = Image.Load(inputFile);

            // Resize image
            image.Mutate(x => x.Resize(new ResizeOptions
            {
                Size = new Size(200, 100),
                Mode = ResizeMode.Max
            }));

            // Save resized image to stream
            image.Save(outputFile, new JpegEncoder());

            logger.LogInformation($"Successfully resized and saved image {filename}");

        }
    }

}
