using System.Text;

public class Grid
{
    public Grid()
    {
        Pixels = new List<List<Pixel>>();
    }

    public void PlaceSanta(int x, int y)
    {
        Pixels[x][y] = new Pixel('S', true);
    }
    public void Render()
    {
        Console.Clear();
        foreach (var row in Pixels)
        {
            foreach (var pixel in row)
            {
                if (pixel.IsSanta)
                    RenderSanta(pixel);
                else
                    Console.Write(pixel.PixelValue);
            }

            Console.WriteLine();
        }
    }

    private void RenderSanta(Pixel pixel)
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Magenta;
        Console.Write(pixel.PixelValue);
        Console.ResetColor();
    }

    public List<List<Pixel>> Pixels { get; }
}