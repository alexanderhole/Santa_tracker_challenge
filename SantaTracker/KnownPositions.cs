namespace SantaTracker;

class KnownPositions : IKnownPositions
{
    public List<KnownTimings> GetKnownPositions()
    {
        var timings = new List<KnownTimings>()
        {
            new() { PlaceName = "Egvekinot", Eta = new DateTime(2022, 12, 24, 21, 00, 00), RelativePositionX = 0.12, RelativePositionY = 0.93 },
            new() { PlaceName = "Auckland", Eta = new DateTime(2022, 12, 24, 22, 00, 00), RelativePositionX = 0.42, RelativePositionY = 0.894},
            new() { PlaceName = "Jakarta", Eta = new DateTime(2022, 12, 24, 22, 45, 00), RelativePositionX = 0.33, RelativePositionY = 0.75},
            new() { PlaceName = "Astana", Eta = new DateTime(2022, 12, 24, 23, 30, 00), RelativePositionX = 0.21, RelativePositionY = 0.65},
            new() { PlaceName = "Pretoria", Eta = new DateTime(2022, 12, 25, 00, 45, 00), RelativePositionX = 0.38, RelativePositionY = 0.538},
            new() { PlaceName = "Paris", Eta = new DateTime(2022, 12, 25, 1, 30, 00), RelativePositionX = 0.18, RelativePositionY = 0.483},
            new() { PlaceName = "Reykjavík", Eta = new DateTime(2022, 12, 25, 2, 30, 00), RelativePositionX = 0.12, RelativePositionY = 0.427},
            new() { PlaceName = "Fermont", Eta = new DateTime(2022, 12, 25, 3, 00, 00), RelativePositionX = 0.16, RelativePositionY = 0.294},
            new() { PlaceName = "New York City", Eta = new DateTime(2022, 12, 25, 3, 45, 00), RelativePositionX = 0.19, RelativePositionY = 0.294},
            new() { PlaceName = "Los Angeles", Eta = new DateTime(2022, 12, 25, 4, 45, 00), RelativePositionX = 0.22, RelativePositionY = 0.155},
            new() { PlaceName = "Mexico City", Eta = new DateTime(2022, 12, 25, 5, 30, 00), RelativePositionX = 0.26, RelativePositionY = 0.205},
            new() { PlaceName = "Bogotá", Eta = new DateTime(2022, 12, 25, 6, 15, 00), RelativePositionX = 0.30, RelativePositionY = 0.277},
            new() { PlaceName = "Belo Horizonte", Eta = new DateTime(2022, 12, 25, 6, 45, 00), RelativePositionX = 0.38, RelativePositionY = 0.327},
            new() { PlaceName = "Ushuaia", Eta = new DateTime(2022, 12, 25, 7, 30, 00), RelativePositionX = 0.47, RelativePositionY = 0.288}
        };
        return timings;
    }
}