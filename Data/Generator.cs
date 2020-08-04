using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageMozaic.Data
{
    public class Generator
    {
        public Mosaic Generate(string image, string srcImageDirectory)
        {
            var imageProcessing = new ProcessImage();
            var imageInfo = new List<Imageinformation>();
            var _mosaic = new Mosaic();

            var di = new DirectoryInfo(srcImageDirectory);
            var files = di.GetFiles("*.jpg", SearchOption.AllDirectories).ToList();
            //Run through images in path and get the average color of the image
            Parallel.ForEach(files, f =>
            {
                using var inputBmp = imageProcessing.Resize(f.FullName);
                var info = imageProcessing.GetAverageColor(inputBmp, f.FullName);
                if (info != null)
                    imageInfo.Add(info);
            });

            using (var source = new Bitmap(image))
            {
                var _colorMap = imageProcessing.CreateMap(source);
                _mosaic = imageProcessing.Render(source, _colorMap, imageInfo);
            }

            return _mosaic;
        }
    }
}
