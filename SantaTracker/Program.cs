// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using SantaTracker;
using SantaTracker.Interfaces;

ServiceCollection sc = new();
sc.AddSingleton<IKnownPositions, KnownPositions>();
sc.AddSingleton<ISantaPredictionService, SantaPredictionService>();
var santaPrediction = sc.BuildServiceProvider().GetService<ISantaPredictionService>();

var startTime = new DateTime(2022, 12, 24, 21, 0, 0, 0);
for (int i = 0; i < 62; i++)
{
    var grid = ImageToText.MineBitmapToAscii("map.bmp");
    var predictPositionOfSanta = santaPrediction.PredictPositionOfSanta(startTime);
    grid.PlaceSanta(predictPositionOfSanta.X,predictPositionOfSanta.y);
    grid.Render();
    Console.WriteLine(startTime);
    Thread.Sleep(200);
    startTime = startTime.AddMinutes(10);
}


