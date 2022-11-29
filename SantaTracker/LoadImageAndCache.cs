using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

public class LoadImageAndCache
{
    private static Image<Rgba32>? CachedImage { get; set; }

    public static Image<Rgba32> GetImage()
    {
        if (CachedImage != null) return CachedImage;
        using var file = new FileStream("map.bmp", FileMode.Open);
        var image = Image.Load<Rgba32>(file);
        image.Mutate(x => x.Resize(MapConstants.MapWidth, MapConstants.MapHeight));
        CachedImage = image;
        return CachedImage;
    }
}