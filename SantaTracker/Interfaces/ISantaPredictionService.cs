namespace SantaTracker;

public interface ISantaPredictionService
{
    (int X, int y) PredictPositionOfSanta(DateTime timeToPredict);
    (int minutesToNextStop, string stopName) GetMinutesToNextStop(DateTime timeToPredict);
}