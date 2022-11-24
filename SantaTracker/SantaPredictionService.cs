using SantaTracker.Interfaces;

namespace SantaTracker;

public class SantaPredictionService : ISantaPredictionService
{
    private readonly IKnownPositions _knownPositions;

    public SantaPredictionService(IKnownPositions knownPositions)
    {
        _knownPositions = knownPositions;
    }

    public (int X, int y) PredictPositionOfSanta(DateTime timeToPredict)
    {
        var knownPositions = _knownPositions.GetKnownPositions().OrderBy(x => x.Eta);
        if (knownPositions.Any(x => x.Eta == timeToPredict))
            return (knownPositions.First(x => x.Eta == timeToPredict).X,knownPositions.First(x => x.Eta == timeToPredict).Y);
        var beforeTime = knownPositions.Last(x => x.Eta < timeToPredict);
        var afterTime = knownPositions.First(x => x.Eta > timeToPredict);
        var timeBetweenKnownTimes = afterTime.Eta - beforeTime.Eta;
        var timeSinceLastStop = timeToPredict - beforeTime.Eta;
        var distanceBetweenStops =  timeSinceLastStop.TotalSeconds / timeBetweenKnownTimes.TotalSeconds;
        var x = (int)Math.Round(((afterTime.X - beforeTime.X) * distanceBetweenStops) + beforeTime.X);
        var y = (int)Math.Round(((afterTime.Y - beforeTime.Y) * distanceBetweenStops) + beforeTime.Y);
        return (x, y);
    }
}