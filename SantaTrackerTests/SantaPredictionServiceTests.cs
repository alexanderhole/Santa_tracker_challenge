using Moq;
using SantaTracker;
using SantaTracker.Interfaces;

namespace SantaTrackerTests;

public class SantaPredictionServiceTests
{
    private readonly SantaPredictionService _service;
    private Mock<IKnownPositions> _knownPositions;

    public SantaPredictionServiceTests()
    {
        _knownPositions = new Mock<IKnownPositions>();
        _service = new SantaPredictionService(_knownPositions.Object);
    }
    
    [Fact]
    public void PredicateSantaPlacement_ShouldReturnExactPlacementOnTheHour()
    {
        var timeToPredict = new DateTime(2022, 12, 24, 9, 0, 0);

        var expectedX = .30;
        var expectedY = .30;
        _knownPositions.Setup(x => x.GetKnownPositions()).Returns(new List<KnownTimings>()
        {
            new() { Eta = timeToPredict, RelativePositionX = expectedX, RelativePositionY = expectedY },
            new() { Eta = new DateTime(2022, 12, 24, 10, 00, 0), RelativePositionX = .40, RelativePositionY = .30 } ,

        });
        var position = _service.PredictPositionOfSanta(timeToPredict);
        
        Assert.Equal(expectedX,position.X);
        Assert.Equal(expectedY, position.y);
    }
    
    [Fact]
    public void PredicateSantaPlacement_ShouldReturnMidWayPoint_OnY_OnHalfHour()
    {
        var timeToPredict = new DateTime(2022, 12, 24, 9, 30, 0);

        _knownPositions.Setup(x => x.GetKnownPositions()).Returns(new List<KnownTimings>()
        {
            new() { Eta = new DateTime(2022, 12, 24, 9, 00, 0), RelativePositionX = 30, RelativePositionY = .30 } ,
            new() { Eta = new DateTime(2022, 12, 24, 10, 00, 0), RelativePositionX = 30, RelativePositionY = .40 } ,

        });
        var position = _service.PredictPositionOfSanta(timeToPredict);
        
        Assert.Equal(30,position.X);
        Assert.Equal(35, position.y);
    }
    
    [Fact]
    public void PredicateSantaPlacement_ShouldReturnMidWayPoint_OnX_OnHalfHour()
    {
        var timeToPredict = new DateTime(2022, 12, 24, 9, 30, 0);

        _knownPositions.Setup(x => x.GetKnownPositions()).Returns(new List<KnownTimings>()
        {
            new() { Eta = new DateTime(2022, 12, 24, 9, 00, 0), RelativePositionX = .30, RelativePositionY = .30 } ,
            new() { Eta = new DateTime(2022, 12, 24, 10, 00, 0), RelativePositionX = .40, RelativePositionY = .30 } ,

        });
        var position = _service.PredictPositionOfSanta(timeToPredict);
        
        Assert.Equal(35,position.X);
        Assert.Equal(30, position.y);
    }
    
    [Fact]
    public void PredicateSantaPlacementShouldReturnQuarterPoint_OnX_OnQuarterPast()
    {
        var timeToPredict = new DateTime(2022, 12, 24, 9, 15, 0);

        _knownPositions.Setup(x => x.GetKnownPositions()).Returns(new List<KnownTimings>()
        {
            new() { Eta = new DateTime(2022, 12, 24, 9, 00, 0), RelativePositionX = .30, RelativePositionY = .30 } ,
            new() { Eta = new DateTime(2022, 12, 24, 10, 00, 0), RelativePositionX = .40,RelativePositionY  = .30 } ,

        });
        var position = _service.PredictPositionOfSanta(timeToPredict);
        
        Assert.Equal(32,position.X);
        Assert.Equal(30, position.y);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(23)]
    [InlineData(18)]
    public void GetMinutesToNextStop_ShouldReturn_CorrectMinutes(int expectedMinutes)
    {
        var timeToPredict = new DateTime(2022, 12, 24, 9, 60 - expectedMinutes, 0);

        _knownPositions.Setup(x => x.GetKnownPositions()).Returns(new List<KnownTimings>()
        {
            new() { Eta = new DateTime(2022, 12, 24, 9, 00, 0), RelativePositionX = .30, RelativePositionY = .30 } ,
            new() { Eta = new DateTime(2022, 12, 24, 10, 00, 0), RelativePositionX = .40, RelativePositionY = .30 } ,

        });
        var minutes = _service.GetMinutesToNextStop(timeToPredict);
        
        Assert.Equal(expectedMinutes, minutes.minutesToNextStop);
    }
}