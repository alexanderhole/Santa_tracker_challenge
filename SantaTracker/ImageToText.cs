public class ImageToText
{
    public static Grid BitmapToGrid()
    {
        var image = LoadImageAndCache.GetImage();
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

}