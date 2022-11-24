using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

public class ImageToText
{
    public static string LibBitmapToAscii(string fileName)
    {
        var image = Image();
        var sb = new StringBuilder();
        return AscArt.GenerateAsciiArt(image, (int)Math.Round((double)(image.Width * 0.8)));
    }

    public static Grid MineBitmapToAscii(string fileName)
    {
        var image = Image();
        var grid = new Grid();
        for (int y = 0; y < image.Height; y++)
        {
            var currentRow = new List<Pixel>();
            //Stops it being stretched as much
            if (y % 2 > 0)
                continue;

            grid.Pixels.Add(currentRow);
            for (int x = 0; x < image.Width; x++)
            {
                if (image[x, y].B < 100)
                    currentRow.Add(new Pixel('@'));
                else if (image[x, y].B < 200)
                    currentRow.Add(new Pixel('*'));
                else
                    currentRow.Add(new Pixel(' '));
            }

        }

        return grid;
    }

    private static Image<Rgba32> Image()
    {
        using var file = new FileStream("map.bmp", FileMode.Open);
        var image = SixLabors.ImageSharp.Image.Load<Rgba32>(file);
        image.Mutate(x => x.Resize(180, 100));
        return image;
    }
}