public class Pixel
{
    public Pixel(char value, bool isSanta = false)
    {
        PixelValue = value;
        IsSanta = isSanta;
    }

    public bool IsSanta { get; set; }

    public char PixelValue { get; set; }
}