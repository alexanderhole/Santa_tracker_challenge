using SantaTracker.Interfaces;

namespace SantaTracker;

class KnownPositions : IKnownPositions
{
    public List<KnownTimings> GetKnownPositions()
    {
        var timings = new List<KnownTimings>()
        {
            new() { PlaceName = "Egvekinot", Eta = new DateTime(2022, 12, 24, 21, 00, 00), X = 12, Y = 168 },
            new() { PlaceName = "Auckland", Eta = new DateTime(2022, 12, 24, 22, 00, 00), X = 42, Y = 161},
            new() { PlaceName = "Jakarta", Eta = new DateTime(2022, 12, 24, 22, 45, 00), X = 33, Y = 135},
            new() { PlaceName = "Astana", Eta = new DateTime(2022, 12, 24, 23, 30, 00), X = 21, Y = 117},
            new() { PlaceName = "Pretoria", Eta = new DateTime(2022, 12, 25, 00, 45, 00), X = 38, Y = 97},
            new() { PlaceName = "Paris", Eta = new DateTime(2022, 12, 25, 1, 30, 00), X = 18, Y = 87},
            new() { PlaceName = "Reykjavík", Eta = new DateTime(2022, 12, 25, 2, 30, 00), X = 12, Y = 77},
            new() { PlaceName = "Fermont", Eta = new DateTime(2022, 12, 25, 3, 00, 00), X = 16, Y = 53},
            new() { PlaceName = "New York City", Eta = new DateTime(2022, 12, 25, 3, 45, 00), X = 19, Y = 53},
            new() { PlaceName = "Los Angeles", Eta = new DateTime(2022, 12, 25, 4, 45, 00), X = 22, Y = 28},
            new() { PlaceName = "Mexico City", Eta = new DateTime(2022, 12, 25, 5, 30, 00), X = 26, Y = 37},
            new() { PlaceName = "Bogotá", Eta = new DateTime(2022, 12, 25, 6, 15, 00), X = 30, Y = 50},
            new() { PlaceName = "Belo Horizonte", Eta = new DateTime(2022, 12, 25, 6, 45, 00), X = 38, Y = 59},
            new() { PlaceName = "Ushuaia", Eta = new DateTime(2022, 12, 25, 7, 30, 00), X = 47, Y = 52}
        };
        return timings;
    }
}