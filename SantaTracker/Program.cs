// See https://aka.ms/new-console-template for more information

ServiceCollection sc = new();
sc.AddSingleton<IKnownPositions, KnownPositions>();
sc.AddSingleton<ISantaPredictionService, SantaPredictionService>();
var santaPredictionService = sc.BuildServiceProvider().GetService<ISantaPredictionService>();
void RunAnimation()
{
    var startTime = new DateTime(2022, 12, 24, 21, 0, 0, 0);
    for (int i = 0; i < 62; i++)
    {
        PrintMap(startTime);
        Thread.Sleep(1000);
        startTime = startTime.AddMinutes(10);
    }
}
void PrintMap(DateTime dateTime)
{
    var grid = ImageToText.BitmapToGrid();
    var predictPositionOfSanta = santaPredictionService.PredictPositionOfSanta(dateTime);
    grid.PlaceSanta(predictPositionOfSanta.X, predictPositionOfSanta.y);
    grid.Render();
    var nextStopInfo = santaPredictionService.GetMinutesToNextStop(dateTime);
    Console.WriteLine($"Currently its {dateTime.TimeOfDay} next stop is {nextStopInfo.stopName} in {nextStopInfo.minutesToNextStop} minutes");
}
void RunLoop()
{
    Console.WriteLine("Please make a selection.");
    Console.WriteLine("A) Watch santas route.");
    Console.WriteLine("B) Enter a time for a prediction\n");
    var consoleKeyInfo = Console.ReadKey();
    Console.WriteLine();
    if(consoleKeyInfo.Key == ConsoleKey.A)
        RunAnimation();
    if(consoleKeyInfo.Key == ConsoleKey.B)
    {
        DateTime? date = null;
        while (date == null)
        {
            date = GetDateTime();
        }
        PrintMap(date.Value);
    }

    DateTime? GetDateTime()
    {
        Console.WriteLine("Please enter date and press enter (format such as 2022-12-24 23:58:00)");
        try
        {
            return DateTime.Parse(Console.ReadLine());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Could not parse date time try again \n");
        }

        return null;
    }
}

while (true)
{
    RunLoop();
}

