namespace SantaTracker;

public class SantaPredictionService : ISantaPredictionService
{
    private readonly IKnownPositions _knownPositions;

    public SantaPredictionService(IKnownPositions knownPositions)
    {
        _knownPositions = knownPositions;
    }

    public (int minutesToNextStop, string stopName) GetMinutesToNextStop(DateTime timeToPredict)
    {
        var currentStops = GetBeforeAndAfterStops(timeToPredict);
        var timeSinceToNextStop = currentStops.afterTime.Eta  - timeToPredict;
        return ((int)timeSinceToNextStop.TotalMinutes, currentStops.afterTime.PlaceName);
    }
    public (int X, int y) PredictPositionOfSanta(DateTime timeToPredict)
    {
        var currentStops = GetBeforeAndAfterStops(timeToPredict);
        var distanceBetweenStops = DistanceBetweenStops(timeToPredict, currentStops);
        var x = Round(currentStops.beforeTime.X, currentStops.afterTime.X, distanceBetweenStops);
        var y = Round(currentStops.beforeTime.Y, currentStops.afterTime.Y, distanceBetweenStops);
        return (x, y);
    }

    private static int Round(int beforeTime, int afterTime, double distanceBetweenStops)
    {
        return (int)Math.Round(((afterTime - beforeTime) * distanceBetweenStops) + beforeTime);
    }

    private static double DistanceBetweenStops(DateTime timeToPredict,
        (KnownTimings beforeTime, KnownTimings afterTime) currentStops)
    {
        if (currentStops.beforeTime == currentStops.afterTime) return 0;
        var timeBetweenKnownTimes = currentStops.afterTime.Eta - currentStops.beforeTime.Eta;
        var timeSinceLastStop = timeToPredict - currentStops.beforeTime.Eta;
        var distanceBetweenStops = timeSinceLastStop.TotalSeconds / timeBetweenKnownTimes.TotalSeconds;
        return distanceBetweenStops;
    }

    private (KnownTimings beforeTime, KnownTimings afterTime) GetBeforeAndAfterStops(DateTime timeToPredict)
    {
        var knownPositions = _knownPositions.GetKnownPositions().OrderBy(x => x.Eta);
        var beforeTime = knownPositions.LastOrDefault(x => x.Eta <= timeToPredict);
        if (beforeTime == null)
            beforeTime = knownPositions.First();
        var afterTime = knownPositions.First(x => x.Eta >= timeToPredict);
        return (beforeTime, afterTime);
    }
}