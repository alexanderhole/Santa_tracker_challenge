using Microsoft.VisualBasic;

namespace SantaTracker;

public class KnownTimings
{
    public string PlaceName { get; set; }
    public DateTime Eta { get; set; }

    public int X => (int)Math.Floor(RelativePositionX * MapConstants.MapHeight);
    public int Y => (int)Math.Floor(RelativePositionY * MapConstants.MapWidth);

    public double RelativePositionX { get; set; }
    public double RelativePositionY { get; set; }
}