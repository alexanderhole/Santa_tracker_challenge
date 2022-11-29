public class Pixel
{
    public Pixel(char value, bool isSanta = false)
    {
        PixelValue = value;
        IsSanta = isSanta;
    }

    public bool IsSanta { get; }

    public char PixelValue { get; }
}